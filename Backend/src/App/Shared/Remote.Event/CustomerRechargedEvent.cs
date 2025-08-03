using Dkd.Shared.Remote.Event;

namespace Dkd.App.Remote.Event;

/// <summary>
/// Customer recharge event
/// </summary>
[Serializable]
public class CustomerRechargedEvent : EventEntity
{
    public CustomerRechargedEvent()
    {
    }

    public CustomerRechargedEvent(long id, string source, long custmerId, decimal amout, long transactionLogId)
        : base(id, source)
    {
        CustomerId = custmerId;
        Amount = amout;
        TransactionLogId = transactionLogId;
    }

    public long CustomerId { get; init; }
    public decimal Amount { get; init; }
    public long TransactionLogId { get; init; }
}
