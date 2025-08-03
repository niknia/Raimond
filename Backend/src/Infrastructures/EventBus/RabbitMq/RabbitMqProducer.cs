using RabbitMQ.Client;

namespace Dkd.Infra.EventBus.RabbitMq;

public class RabbitMqProducer(IConnectionManager connectionManager, ILogger<RabbitMqProducer> logger)
{
    /*
    /// <summary>
    /// Simple queue, without using an exchange
    /// </summary>
    /// <typeparam name="TMessage"></typeparam>
    /// <param name="queueName"></param>
    /// <param name="message"></param>
    //public virtual void BasicPublish<TMessage>(string queueName, TMessage message)
    //{
    //    _logger.LogInformation($"PushMessage,queueName:{queueName}");

    //    _channel.QueueDeclare(queue: queueName,
    //                          durable: false,
    //                          exclusive: false,
    //                          autoDelete: false,
    //                          arguments: null);

    //    var content = JsonSerializer.Serialize(message);
    //    var body = Encoding.UTF8.GetBytes(content);

    //    _channel.BasicPublish(exchange: string.Empty,
    //                          routingKey: queueName,
    //                          basicProperties: null,
    //                          body: body);
    //}
    */

    public virtual Task BasicPublishAsync<TMessage>(string exchange
        , string routingKey
        , TMessage message
        , BasicProperties? basicProperties = null
        , bool mandatory = false
        , CancellationToken cancellationToken = default
    )
    {
        Policy.Handle<Exception>()
              .WaitAndRetry(3, retryAttempt => TimeSpan.FromSeconds(1), (ex, time, retryCount, content) =>
              {
                  logger.LogError(ex, "Policy.Handle.RetryCount：{retryCount}", retryCount);
              })
              .Execute(async () =>
              {
                  var content = message as string ?? JsonSerializer.Serialize(message);
                  var body = Encoding.UTF8.GetBytes(content);
                  //When the mandatory flag is set to true, if the exchange cannot find a suitable queue to store the message
                  //based on its type and message routingKey, the broker will call basic.return to return the message to the producer;
                  //When mandatory is set to false, the broker will directly discard the message in the above case

                  using var channel = await connectionManager.Connection.CreateChannelAsync();
                  await channel.BasicPublishAsync(exchange, routingKey, mandatory, basicProperties ?? new BasicProperties(), body, cancellationToken);
                  //Enable publish message confirmation mode
                  //_channel.ConfirmSelect();
                  //Check if message reached the server
                  //bool publishStatus = _channel.WaitForConfirms();
              });
        return Task.CompletedTask;
    }

    public virtual BasicProperties CreateBasicProperties() => new();

    //public void Dispose()
    //{
    //    Dispose(true);
    //    GC.SuppressFinalize(this);
    //}

    //protected virtual void Dispose(bool disposing)
    //{
    //    if (disposing)
    //    {
    //        if (_channel != null)
    //            _channel.Dispose();
    //    }
    //}
}
