using Dkd.Shared.Remote.Event;

namespace Dkd.App.Remote.Event;

/// <summary>
/// Order canceled event
/// </summary>
[Serializable]
public sealed class OrderCanceledEvent : EventEntity
{
    public OrderCanceledEvent()
    {
    }

    public OrderCanceledEvent(long id, string eventSource, long orderId)
        : base(id, eventSource)
    {
        OrderId = orderId;
    }

    public long OrderId { get; set; }
}
