namespace Dkd.Infra.EventBus.RabbitMq;

/// <summary>
/// Queue configuration information
/// </summary>
public class QueueConfig
{
    /// <summary>
    /// Queue name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Dead letter queue name, requires dead letter exchange configuration first
    /// </summary>
    public string DeadQueueName
    {
        get { return $"dead-letter-{Name}"; }
    }

    /// <summary>
    /// Whether to persist the queue
    /// </summary>
    public bool Durable { get; set; }

    /// <summary>
    /// exclusive: Whether the queue is exclusive, has two functions:
    /// 1. Whether the queue will be automatically deleted when the connection is closed (connection.close());
    /// 2. Whether the queue is private. If not exclusive, two consumers can access the same queue without issues;
    ///    If exclusive, the current queue will be locked, and other channels cannot access it. Forcing access will throw an exception.
    ///   Generally set to true for scenarios where a queue can only have one consumer.
    /// </summary>
    public bool Exclusive { get; set; }

    /// <summary>
    /// Whether to auto-delete, whether the queue will be automatically deleted when the last consumer disconnects
    /// </summary>
    public bool AutoDelete { get; set; }

    /// <summary>
    /// Queue extension parameter configuration
    /// x-dead-letter-exchange: Set the current queue's DLX (Dead Letter Exchange)
    /// x-dead-letter-routing-key: Set the routing key for DLX, which DLX uses to find the queue for storing dead letter messages
    /// x-message-ttl: Set the message's time-to-live, i.e., expiration time (in milliseconds)
    /// </summary>
    public IDictionary<string, object?>? Arguments { get; set; }

    /// <summary>
    /// Whether to enable automatic acknowledgment
    /// </summary>
    public bool AutoAck { get; set; }

    /// <summary>
    /// When global=true, it applies to all consumers on the current channel; otherwise, it only applies to consumers created after this setting
    /// </summary>
    public bool Global { get; set; }

    /// <summary>
    /// Only effective when manual acknowledgment is enabled
    /// Whether multiple messages can be acknowledged at once
    /// </summary>
    public bool AckMultiple { get; set; }

    /// <summary>
    /// Only effective when manual acknowledgment is enabled
    /// requeue = true: Put back into the queue
    /// requeue = false: If dead letter queue is configured, message will be transferred to dead letter queue; otherwise, it will be discarded.
    /// </summary>
    public bool RejectRequeue { get; set; }

    /// <summary>
    /// Only effective when manual acknowledgment is enabled
    /// Can only send one message to the consumer at a time, and will not send more messages until the consumer acknowledges
    /// </summary>
    public ushort PrefetchCount { get; set; }
}
