namespace CustomerRegistrationVerification.Api.Models;

public record RegisterCustomerRequest(
    string FullName,
    string Email,
    string? Phone,
    string? Country
);