namespace CustomerRegistrationVerification.Api.Interfaces;

using CustomerRegistrationVerification.Api.Models;

public interface ICustomerRegistrationFactory
{
    CustomerRegistrationMessage Create(RegisterCustomerRequest request);
}