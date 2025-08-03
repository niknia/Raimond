using Dkd.Infra.Core.Guard;
using Dkd.Shared.Application.Extensions;
using DotNetCore.CAP;
using DotNetCore.CAP.Messages;

namespace Dkd.Shared.Application.Registrar;

public abstract partial class AbstractApplicationDependencyRegistrar
{
    /// <summary>
    /// Register the CAP component (an open source component that implements event bus and eventual consistency (distributed transactions))
    /// </summary>
    /// <param name="subscribers"></param>
    /// <param name="failedThresholdCallback"></param>
    /// <exception cref="ArgumentNullException"></exception>
    protected virtual void AddCapEventBus(IEnumerable<Type> subscribers, Action<FailedInfo>? failedThresholdCallback = null)
    {
        ArgumentNullException.ThrowIfNull(subscribers, nameof(subscribers));
        Checker.Argument.ThrowIfNullOrCountLEZero(subscribers, nameof(subscribers));

        var connectionString = Configuration.GetValue<string>(NodeConsts.Mysql_ConnectionString) ?? throw new InvalidDataException("MySql ConnectionString is null");
        var rabbitMQOptions = Configuration.GetRequiredSection(NodeConsts.RabbitMq).Get<RabbitMQOptions>() ?? throw new InvalidDataException(nameof(RabbitMQOptions));
        var clientProvidedName = ServiceInfo.Id;
        var version = ServiceInfo.Version;
        var groupName = $"cap.{ServiceInfo.ShortName}.{this.GetEnvShortName()}";
        Services.AddAdncInfraCap(subscribers, capOptions =>
        {
            SetCapBasicInfo(capOptions, version, groupName, failedThresholdCallback);
            SetCapRabbitMQInfo(capOptions, rabbitMQOptions, clientProvidedName);
            SetCapMySqlInfo(capOptions, connectionString);
        }, null, Lifetime);
    }

    protected void SetCapRabbitMQInfo(CapOptions capOptions, RabbitMQOptions rabbitMQOptions, string clientProvidedName)
    {
        capOptions.UseRabbitMQ(mqOptions =>
        {
            mqOptions.HostName = rabbitMQOptions.HostName;
            mqOptions.VirtualHost = rabbitMQOptions.VirtualHost;
            mqOptions.Port = rabbitMQOptions.Port;
            mqOptions.UserName = rabbitMQOptions.UserName;
            mqOptions.Password = rabbitMQOptions.Password;
            mqOptions.ConnectionFactoryOptions = (facotry) =>
            {
                facotry.ClientProvidedName = clientProvidedName;
            };
        });
    }

    protected void SetCapMySqlInfo(CapOptions capOptions, string connectionString)
    {
        capOptions.UseMySql(config =>
        {
            config.ConnectionString = connectionString;
            config.TableNamePrefix = "cap";
        });
    }

    protected void SetCapBasicInfo(CapOptions capOptions, string version, string groupName, Action<FailedInfo>? failedThresholdCallback = null)
    {
        capOptions.Version = version;
        //Default value: cap.queue.{assembly name}, mapped to Queue Names in RabbitMQ.
        capOptions.DefaultGroupName = groupName;
        //Default value: 60 seconds, retry & interval
        //By default, the retry will start 4 minutes after the failure of sending and consuming messages. This is to avoid possible problems caused by delays in setting message status.
        //Failures in the process of sending and consuming messages will be immediately retried 3 times. After 3 times, the retry polling will be entered, and the FailedRetryInterval configuration will take effect.
        capOptions.FailedRetryInterval = 60;
        //Default value: 50, the maximum number of retries. When this setting value is reached, no more retries will be made. The maximum number of retries can be set by changing this parameter.
        capOptions.FailedRetryCount = 50;
        //Default value: NULL, failure callback of the retry threshold. When the retry reaches the value set by FailedRetryCount, this Action callback will be called.
        //You can specify this callback to receive notifications of the maximum number of failures so that you can intervene manually. For example, send an email or SMS.
        capOptions.FailedThresholdCallback = failedThresholdCallback;
        //Default value: 24*3600 seconds (after 1 day), the expiration time of successful messages (seconds).
        //When a message is sent or consumed successfully, it will be deleted from Persistent when the time reaches SucceedMessageExpiredAfter seconds. You can set the expiration time by specifying this value.
        capOptions.SucceedMessageExpiredAfter = 24 * 3600;
        //Default value: 1, the number of threads that the consumer thread processes messages in parallel. When this value is greater than 1, the order of message execution cannot be guaranteed.
        capOptions.ConsumerThreadCount = 1;
    }
}
