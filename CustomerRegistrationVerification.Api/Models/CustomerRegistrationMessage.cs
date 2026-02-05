namespace CustomerRegistrationVerification.Api.Models;

public record CustomerRegistrationMessage(
    string CustomerId,
    string FullName,
    string Email,
    string? Phone,
    string? Country,
    DateTime RegisteredAt
);