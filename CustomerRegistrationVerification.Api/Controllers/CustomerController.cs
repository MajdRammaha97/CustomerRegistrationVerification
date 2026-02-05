namespace CustomerRegistrationVerification.Api.Controllers;

using Microsoft.AspNetCore.Mvc;

using CustomerRegistrationVerification.Core.Enums;

using CustomerRegistrationVerification.Api.Models;
using CustomerRegistrationVerification.Api.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class CustomerController(ICustomerRegistrationFactory _registrationFactory, IServiceBusPublisher _publisher) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterCustomerRequest request, CancellationToken cancellationToken)
    {
        var registrationMessage = _registrationFactory.Create(request);
        await _publisher.PublishCustomerRegistrationAsync(registrationMessage, cancellationToken);
        return Accepted(new { registrationMessage.CustomerId, Status = nameof(RegistrationStatus.QueuedForVerification) });
    }
}