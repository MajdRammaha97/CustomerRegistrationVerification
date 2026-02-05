using Azure.Messaging.ServiceBus;

using CustomerRegistrationVerification.Api.Options;
using CustomerRegistrationVerification.Api.Services;
using CustomerRegistrationVerification.Api.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.Configure<ServiceBusOptions>(builder.Configuration.GetSection("ServiceBus"));

builder.Services.AddSingleton(sp =>
{
    var opts = sp.GetRequiredService<Microsoft.Extensions.Options.IOptions<ServiceBusOptions>>().Value;
    return new ServiceBusClient(opts.ConnectionString);
});

builder.Services.AddScoped<IServiceBusPublisher, ServiceBusPublisher>();
builder.Services.AddScoped<ICustomerRegistrationFactory, CustomerRegistrationFactory>();

var app = builder.Build();

app.MapControllers();

app.Run();