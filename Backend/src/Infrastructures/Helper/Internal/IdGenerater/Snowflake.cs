using System.Text;

namespace Adnc.Infra.Helper.Internal.IdGenerater;

/// <summary>
/// Snowflake ID
/// Twitter_Snowflake
/// SnowFlake structure is as follows (each part separated by -)
/// 0 - 0000000000 0000000000 0000000000 0000000000 0 - 00000 - 00000 - 000000000000
/// 1-bit identifier, since long is signed in Java, the highest bit is the sign bit, 0 for positive numbers and 1 for negative numbers, so IDs are generally positive, highest bit is 0
/// 41-bit timestamp (millisecond level), note that the 41-bit timestamp is not storing the current timestamp, but storing the difference between timestamps (current timestamp - start timestamp),
/// 41-bit timestamp can be used for 69 years, year T = (1L << 41) / (1000L * 60 * 60 * 24 * 365) = 69
/// The start timestamp here is generally the time when our ID generator starts to be used, specified by our program (like the startTime property of the IdWorker class below).
/// 10-bit data machine bits, can be deployed on 1024 nodes, including 5-bit datacenterId and 5-bit workerId
/// 12-bit sequence, millisecond counter, 12-bit sequence number supports generating 4096 ID sequences per millisecond per node (same machine, same timestamp)
/// Total adds up to exactly 64 bits, a Long type.
/// The advantages of SnowFlake are: overall sorted by time increment, and no ID collision in the entire distributed system (distinguished by datacenter ID and machine ID),
/// and high efficiency, tested to generate up to 4,096,000 IDs per second on a single machine
/// </summary>
[Obsolete("Native snowflake algorithm, now deprecated")]
internal class Snowflake
{
    // Start timestamp (new DateTime(2020, 1, 1).ToUniversalTime() - Jan1st1970).TotalMilliseconds
    private const long twepoch = 1577808000000L;

    // Number of bits for machine id
    private const int workerIdBits = 5;

    // Number of bits for data identifier id
    private const int datacenterIdBits = 5;

    // Maximum machine id supported, result is 31 (this shift algorithm can quickly calculate the maximum decimal number that can be represented by several binary digits)
    private const long maxWorkerId = -1L ^ (-1L << workerIdBits);

    // Maximum data identifier id supported, result is 31
    private const long maxDatacenterId = -1L ^ (-1L << datacenterIdBits);

    // Number of bits for sequence in id
    private const int sequenceBits = 12;

    // Data identifier id shifted left by 17 bits (12+5)
    private const int datacenterIdShift = sequenceBits + workerIdBits;

    // Machine ID shifted left by 12 bits
    private const int workerIdShift = sequenceBits;

    // Timestamp shifted left by 22 bits (5+5+12)
    private const int timestampLeftShift = sequenceBits + workerIdBits + datacenterIdBits;

    // Mask for generating sequence, here is 4095 (0b111111111111=0xfff=4095)
    private const long sequenceMask = -1L ^ (-1L << sequenceBits);

    // Data center ID (0~31)
    public long datacenterId { get; private set; }

    // Working machine ID (0~31)
    public long workerId { get; private set; }

    // Millisecond sequence (0~4095)
    public long sequence { get; private set; }

    // Last timestamp when ID was generated
    public long lastTimestamp { get; private set; }

    private static readonly DateTime Jan1st1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    private static readonly object _syncRoot = new object(); //Lock object

    private static Snowflake _snowflake;

    /// <summary>
    /// Create an instance
    /// </summary>
    /// <returns></returns>
    public static Snowflake GetInstance(long datacenterId = 1, long workerId = 1)
    {
        if (_snowflake == null)
        {
            lock (_syncRoot)
            {
                _snowflake ??= new Snowflake(datacenterId, workerId);
            }
        }
        else
        {
            if (_snowflake.datacenterId != datacenterId || _snowflake.workerId != workerId)
                throw new Exception($"Original datacenterId:{_snowflake.datacenterId},workerId={_snowflake.workerId}");
        }
        return _snowflake;
    }

    /// <summary>
    /// Snowflake ID
    /// </summary>
    /// <param name="datacenterId">Data center ID</param>
    /// <param name="workerId">Working machine ID</param>
    private Snowflake(long datacenterId, long workerId)
    {
        if (datacenterId > maxDatacenterId || datacenterId < 0)
        {
            throw new Exception(string.Format("datacenter Id can't be greater than {0} or less than 0", maxDatacenterId));
        }
        if (workerId > maxWorkerId || workerId < 0)
        {
            throw new Exception(string.Format("worker Id can't be greater than {0} or less than 0", maxWorkerId));
        }
        this.workerId = workerId;
        this.datacenterId = datacenterId;
        this.sequence = 0L;
        this.lastTimestamp = -1L;
    }

    /// <summary>
    /// Get next ID
    /// </summary>
    /// <returns></returns>
    public long NextId()
    {
        lock (_syncRoot)
        {
            long timestamp = GetCurrentTimestamp();
            if (timestamp > lastTimestamp) //Timestamp changed, reset millisecond sequence
            {
                sequence = 0L;
            }
            else if (timestamp == lastTimestamp) //If generated at the same time, perform millisecond sequence
            {
                sequence = (sequence + 1) & sequenceMask;
                if (sequence == 0) //Millisecond sequence overflow
                {
                    timestamp = GetNextTimestamp(lastTimestamp); //Block until next millisecond, get new timestamp
                }
            }
            else   //Current time is less than last ID generation timestamp, system clock was moved backwards, need to handle clock rollback
            {
                sequence = (sequence + 1) & sequenceMask;
                if (sequence > 0)
                {
                    timestamp = lastTimestamp;     //Stay at last timestamp, wait for system time to catch up to fully resolve clock rollback issue
                }
                else   //Millisecond sequence overflow
                {
                    timestamp = lastTimestamp + 1;   //Directly advance to next millisecond
                }
                //throw new Exception(string.Format("Clock moved backwards.  Refusing to generate id for {0} milliseconds", lastTimestamp - timestamp));
            }

            lastTimestamp = timestamp;       //Last timestamp when ID was generated

            //Shift and combine through OR operation to form 64-bit ID
            var id = ((timestamp - twepoch) << timestampLeftShift)
                    | (datacenterId << datacenterIdShift)
                    | (workerId << workerIdShift)
                    | sequence;
            return id;
        }
    }

    /// <summary>
    /// Block until next millisecond, until new timestamp is obtained
    /// </summary>
    /// <param name="lastTimestamp">Last timestamp when ID was generated</param>
    /// <returns>Current timestamp</returns>
    private long GetNextTimestamp(long lastTimestamp)
    {
        long timestamp = GetCurrentTimestamp();
        while (timestamp <= lastTimestamp)
        {
            timestamp = GetCurrentTimestamp();
        }
        return timestamp;
    }

    /// <summary>
    /// Get current timestamp
    /// </summary>
    /// <returns></returns>
    private long GetCurrentTimestamp()
    {
        return (long)(DateTime.UtcNow - Jan1st1970).TotalMilliseconds;
    }

    /// <summary>
    /// Analyze snowflake ID
    /// </summary>
    /// <returns></returns>
    public static string AnalyzeId(long Id)
    {
        StringBuilder sb = new StringBuilder();

        var timestamp = (Id >> timestampLeftShift);
        var time = Jan1st1970.AddMilliseconds(timestamp + twepoch);
        sb.Append(time.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss:fff"));

        var datacenterId = (Id ^ (timestamp << timestampLeftShift)) >> datacenterIdShift;
        sb.Append("_" + datacenterId);

        var workerId = (Id ^ ((timestamp << timestampLeftShift) | (datacenterId << datacenterIdShift))) >> workerIdShift;
        sb.Append("_" + workerId);

        var sequence = Id & sequenceMask;
        sb.Append("_" + sequence);

        return sb.ToString();
    }
}
