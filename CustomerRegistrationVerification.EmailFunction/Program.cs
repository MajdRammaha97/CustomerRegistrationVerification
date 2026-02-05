using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

using CustomerRegistrationVerification.Core.Constants;

using CustomerRegistrationVerification.EmailFunction.Options;
using CustomerRegistrationVerification.EmailFunction.Services;
using CustomerRegistrationVerification.EmailFunction.Interfaces;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices(services =>
    {
        services.Configure<EmailOptions>(options =>
        {
            options.SmtpHost =
                Environment.GetEnvironmentVariable("SmtpHost")
                ?? EmailConstants.DefaultSmtpHost;

            options.SmtpPort =
                int.TryParse(Environment.GetEnvironmentVariable("SmtpPort"), out var port)
                    ? port
                    : EmailConstants.DefaultSmtpPort;

            options.SmtpUser =
                Environment.GetEnvironmentVariable("SmtpUser")
                ?? throw new InvalidOperationException("SmtpUser missing");

            options.SmtpPassword =
                Environment.GetEnvironmentVariable("SmtpPassword")
                ?? throw new InvalidOperationException("SmtpPassword missing");

            options.FromEmail =
                Environment.GetEnvironmentVariable("FromEmail")
                ?? options.SmtpUser;

            options.FromName =
                Environment.GetEnvironmentVariable("FromName")
                ?? EmailConstants.DefaultFromName;

            options.Subject =
                Environment.GetEnvironmentVariable("EmailSubject")
                ?? EmailConstants.DefaultSubject;
        });

        services.AddSingleton<IEmailSender, SmtpEmailSender>();
    }).Build();

host.Run();