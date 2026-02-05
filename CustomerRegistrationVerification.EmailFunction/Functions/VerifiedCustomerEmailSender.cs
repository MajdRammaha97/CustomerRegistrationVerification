namespace CustomerRegistrationVerification.EmailFunction.Functions;

using System.Text.Json;

using Microsoft.Extensions.Logging;
using Microsoft.Azure.Functions.Worker;

using CustomerRegistrationVerification.EmailFunction.Models;
using CustomerRegistrationVerification.EmailFunction.Interfaces;

public class VerifiedCustomerEmailSender(ILogger<VerifiedCustomerEmailSender> _logger, IEmailSender _emailSender)
{
    [Function(nameof(VerifiedCustomerEmailSender))]
    public async Task Run(
        [ServiceBusTrigger("verified-customer", Connection = "ServiceBusConnection")] string messageBody,
        CancellationToken cancellationToken)
    {
        try
        {
            var model = JsonSerializer.Deserialize<VerifiedCustomerMessage>(messageBody)
                    ?? throw new InvalidOperationException("Invalid message payload.");

            await _emailSender.SendAsync(model.FullName, model.Email, model.RegisteredAt, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to send email.");
        }
    }
}