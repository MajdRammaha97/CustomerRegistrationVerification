namespace CustomerRegistrationVerification.EmailFunction.Services;

using System.Net;
using System.Net.Mail;

using Microsoft.Extensions.Options;

using CustomerRegistrationVerification.Core.Constants;

using CustomerRegistrationVerification.EmailFunction.Options;
using CustomerRegistrationVerification.EmailFunction.Interfaces;

public sealed class SmtpEmailSender(IOptions<EmailOptions> options) : IEmailSender
{
    private readonly EmailOptions _emailOptions = options.Value;

    public async Task SendAsync(string toFullName, string toEmail, DateTime registeredAt, CancellationToken cancellationToken)
    {
        var body = EmailTemplates.Body.Replace(EmailPlaceholders.FullName, toFullName)
                                      .Replace(EmailPlaceholders.RegisteredAt, registeredAt.ToString("G"));

        using var smtp = new SmtpClient(_emailOptions.SmtpHost, _emailOptions.SmtpPort)
        {
            EnableSsl = true,
            Credentials = new NetworkCredential(_emailOptions.SmtpUser, _emailOptions.SmtpPassword)
        };

        using var mail = new MailMessage
        {
            From = new MailAddress(_emailOptions.FromEmail, _emailOptions.FromName),
            Subject = _emailOptions.Subject,
            Body = body,
            IsBodyHtml = false
        };

        mail.To.Add(new MailAddress(toEmail));
        await smtp.SendMailAsync(mail, cancellationToken);
    }
}