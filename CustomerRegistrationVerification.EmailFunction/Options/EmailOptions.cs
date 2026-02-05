namespace CustomerRegistrationVerification.EmailFunction.Options;

using CustomerRegistrationVerification.Core.Constants;

public class EmailOptions
{
    public string SmtpHost { get; set; } = EmailConstants.DefaultSmtpHost;
    public int SmtpPort { get; set; } = EmailConstants.DefaultSmtpPort;
    public string SmtpUser { get; set; } = null!;
    public string SmtpPassword { get; set; } = null!;
    public string FromEmail { get; set; } = null!;
    public string FromName { get; set; } = EmailConstants.DefaultFromName;
    public string Subject { get; set; } = EmailConstants.DefaultSubject;
}