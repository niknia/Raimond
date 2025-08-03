using Dkd.Infra.Core.Guard;
using Yitter.IdGenerator;

namespace Dkd.Infra.IdGenerater.Yitter;

public static class IdGenerater
{
    private static bool _isSet;
    private static readonly object _locker = new();

    public static byte WorkerIdBitLength => 6;
    public static byte SeqBitLength => 6;
    public static short MaxWorkerId => (short)(Math.Pow(2.0, WorkerIdBitLength) - 1);
    public static short CurrentWorkerId { get; private set; } = -1;

    /// <summary>
    /// Initialize ID generator
    /// </summary>
    /// <param name="workerId"></param>
    public static void SetWorkerId(ushort workerId)
    {
        if (_isSet)
        {
            throw new InvalidOperationException("allow only once");
        }

        if (workerId > MaxWorkerId || workerId < 0)
        {
            throw new ArgumentException($"worker Id can't be greater than {MaxWorkerId} or less than 0");
        }

        lock (_locker)
        {
            if (_isSet)
            {
                throw new InvalidOperationException("allow only once");
            }

            YitIdHelper.SetIdGenerator(new IdGeneratorOptions(workerId)
            {
                WorkerIdBitLength = WorkerIdBitLength,
                SeqBitLength = SeqBitLength
            });

            CurrentWorkerId = (short)workerId;
            _isSet = true;
        }
    }

    /// <summary>
    /// Get unique ID, by default supports 64 nodes, with 6-bit sequence number per millisecond.
    /// With default configuration, IDs can be used for 71,000 years without repetition
    /// With default configuration, it takes 70 years to reach js Number Max value
    /// By default, 100,000 numbers can be generated in 500 milliseconds.
    /// If speed needs to be improved, SeqBitLength can be modified. When SeqBitLength = 10, 1 million IDs take about 800 milliseconds.
    /// </summary>
    /// <returns>Id</returns>
    public static long GetNextId()
    {
        if (!_isSet)
        {
            throw new InvalidOperationException("please call SetIdGenerator first");
        }

        return YitIdHelper.NextId();
    }

    public static long[] GetNextIds(int number)
    {
        Checker.Argument.ThrowIfOutOfRange(number, 1, 100000, nameof(number));

        var ids = new long[number];
        for (var index = 0; index < number; index++)
        {
            ids[index] = YitIdHelper.NextId();
        }
        return ids;
    }

    public static string GetNextIdString(string prefix)
    {
        return prefix.Trim().ToUpper() + GetNextId().ToString();
    }
}
