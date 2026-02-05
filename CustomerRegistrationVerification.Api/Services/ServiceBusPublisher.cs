namespace CustomerRegistrationVerification.Api.Services;

using System.Text.Json;

using Microsoft.Extensions.Options;

using Azure.Messaging.ServiceBus;

using CustomerRegistrationVerification.Api.Options;
using CustomerRegistrationVerification.Api.Interfaces;

public sealed class ServiceBusPublisher : IServiceBusPublisher
{
    private const string _jsonContentType = "application/json";
    private readonly string _registrationQueueName;
    private readonly ServiceBusSender _sender;

    public ServiceBusPublisher(ServiceBusClient client, IOptions<ServiceBusOptions> options)
    {
        _registrationQueueName = options.Value.CustomerRegistrationQueueName;
        _sender = client.CreateSender(_registrationQueueName);
    }

    public async Task PublishCustomerRegistrationAsync<T>(T message, CancellationToken cancellationToken)
    {
        var json = JsonSerializer.Serialize(message);
        var sbMessage = new ServiceBusMessage(json)
        {
            ContentType = _jsonContentType,
            Subject = _registrationQueueName
        };

        await _sender.SendMessageAsync(sbMessage, cancellationToken);
    }
}