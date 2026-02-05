namespace CustomerRegistrationVerification.EmailFunction.Interfaces;

public interface IEmailSender
{
    Task SendAsync(string toFullName, string toEmail, DateTime registeredAt, CancellationToken cancellationToken);
}