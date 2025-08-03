using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Dkd.Infra.EventBus.RabbitMq;

public abstract class BaseRabbitMqConsumer(IConnectionManager connectionManager, ILogger<dynamic> logger) : IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await RegisterAsync();
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        await DeRegisterAsync();
    }

    /// <summary>
    /// Register consumer
    /// </summary>
    protected virtual async Task RegisterAsync()
    {
        //Get exchange configuration
        var exchange = GetExchageConfig();

        //Get routing keys
        var routingKeys = GetRoutingKeys();

        //Get queue configuration
        var queue = GetQueueConfig();

        //Declare dead letter exchange and queue
        await RegiterDeadExchange(exchange.DeadExchangeName, queue.DeadQueueName, routingKeys, queue.Durable);

        //Declare exchange
        using var channel = await connectionManager.Connection.CreateChannelAsync();
        await channel.ExchangeDeclareAsync(exchange.Name, type: exchange.Type.ToString().ToLower());

        //Declare queue
        await channel.QueueDeclareAsync(queue: queue.Name
            , durable: queue.Durable
            , exclusive: queue.Exclusive
            , autoDelete: queue.AutoDelete
            , arguments: queue.Arguments
        );

        //Bind queue to exchange
        if (routingKeys == null || routingKeys.Length == 0)
        {
            await channel.QueueBindAsync(queue: queue.Name, exchange: exchange.Name, routingKey: string.Empty);
        }
        else
        {
            foreach (var key in routingKeys)
            {
                await channel.QueueBindAsync(queue: queue.Name, exchange: exchange.Name, routingKey: key);
            }
        }

        var consumer = new AsyncEventingBasicConsumer(channel);

        //Disable auto-acknowledgment, these configurations are needed when manual acknowledgment is enabled
        if (!queue.AutoAck)
        {
            await channel.BasicQosAsync(prefetchSize: 0, prefetchCount: queue.PrefetchCount, global: queue.Global);
            await channel.BasicConsumeAsync(queue: queue.Name, consumer: consumer, autoAck: queue.AutoAck);
        }

        consumer.ReceivedAsync += async (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            var result = await Process(ea.Exchange, ea.RoutingKey, message);

            logger.LogDebug("result:{result},message:{message}", result, message);

            //Disable auto-acknowledgment, need to choose acknowledgment based on processing result when manual acknowledgment is enabled
            if (!queue.AutoAck)
            {
                if (result)
                {
                    await channel.BasicAckAsync(ea.DeliveryTag, multiple: queue.AckMultiple);
                }
                else
                {
                    await channel.BasicRejectAsync(ea.DeliveryTag, requeue: queue.RejectRequeue);
                }
            }
        };
    }

    /// <summary>
    /// Deregister/close connection
    /// </summary>
    protected virtual async Task DeRegisterAsync()
    {
        if (connectionManager.Connection != null)
        {
            await connectionManager.Connection.DisposeAsync();
        }
    }

    /// <summary>
    /// Method to process messages
    /// </summary>
    /// <param name="exchange"></param>
    /// <param name="routingKey"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    protected abstract Task<bool> Process(string exchange, string routingKey, string message);

    /// <summary>
    /// Get exchange configuration
    /// </summary>
    /// <returns></returns>
    protected abstract ExchageConfig GetExchageConfig();

    /// <summary>
    /// Get routing keys
    /// </summary>
    /// <returns></returns>
    protected abstract string[] GetRoutingKeys();

    /// <summary>
    /// Get queue configuration
    /// </summary>
    /// <returns></returns>
    protected abstract QueueConfig GetQueueConfig();

    /// <summary>
    /// Get common queue configuration
    /// </summary>
    /// <returns></returns>
    protected QueueConfig GetCommonQueueConfig()
    {
        return new QueueConfig()
        {
            Name = string.Empty
            ,
            AutoDelete = false
            ,
            Durable = false
            ,
            Exclusive = false
            ,
            Global = true
            ,
            AutoAck = false
            ,
            AckMultiple = false
            ,
            PrefetchCount = 1
            ,
            RejectRequeue = false
            ,
            Arguments = null
        };
    }

    /// <summary>
    /// Declare dead letter exchange and queue
    /// </summary>
    protected virtual async Task RegiterDeadExchange(string deadExchangeName, string deadQueueName, string[] routingKeys, bool durable)
    {
        if (!string.IsNullOrWhiteSpace(deadExchangeName))
        {
            using var channel = await connectionManager.Connection.CreateChannelAsync();
            await channel.ExchangeDeclareAsync(deadExchangeName, ExchangeType.Direct.ToString().ToLower());
            await channel.QueueDeclareAsync(queue: deadQueueName, durable: durable, exclusive: false, autoDelete: false, arguments: null);
            foreach (var key in routingKeys)
            {
                await channel.QueueBindAsync(queue: deadQueueName, exchange: deadExchangeName, routingKey: key);
            }
        }
    }
}
