using Dkd.Shared.Remote.Event;

namespace Dkd.App.Remote.Event;

/// <summary>
/// Warehouse quantity blocked event
/// </summary>
[Serializable]
public class WarehouseQtyBlockedEvent : EventEntity
{
    public WarehouseQtyBlockedEvent()
    {
    }

    public WarehouseQtyBlockedEvent(long id, string eventSource, long orderId, bool isSuccess, string remark)
        : base(id, eventSource)
    {
        OrderId = orderId;
        IsSuccess = isSuccess;
        Remark = remark;
    }

    public long OrderId { get; set; }

    public bool IsSuccess { get; set; }

    public string Remark { get; set; } = string.Empty;
}
