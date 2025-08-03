namespace Dkd.Infra.EventBus.RabbitMq;

public enum ExchangeType
{
    //Publish/Subscribe pattern
    Fanout,

    //Routing pattern
    Direct,

    //Wildcard pattern
    Topic
}
