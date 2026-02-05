namespace CustomerRegistrationVerification.Api.Services;

using CustomerRegistrationVerification.Api.Models;
using CustomerRegistrationVerification.Api.Interfaces;

public sealed class CustomerRegistrationFactory : ICustomerRegistrationFactory
{
    public CustomerRegistrationMessage Create(RegisterCustomerRequest request)
    {
        return new CustomerRegistrationMessage(
            Guid.NewGuid().ToString(),
            request.FullName,
            request.Email,
            request.Phone,
            request.Country,
            DateTime.Now
        );
    }
}