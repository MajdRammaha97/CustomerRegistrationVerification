namespace CustomerRegistrationVerification.Api.Interfaces;

public interface IServiceBusPublisher
{
    Task PublishCustomerRegistrationAsync<T>(T message, CancellationToken cancellationToken);
}