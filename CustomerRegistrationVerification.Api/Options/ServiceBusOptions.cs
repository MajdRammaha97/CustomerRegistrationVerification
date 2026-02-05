namespace CustomerRegistrationVerification.Api.Options;

public class ServiceBusOptions
{
    public string ConnectionString { get; set; } = null!;
    public string CustomerRegistrationQueueName { get; set; } = null!;
}