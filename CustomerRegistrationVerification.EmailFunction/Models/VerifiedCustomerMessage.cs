namespace CustomerRegistrationVerification.EmailFunction.Models;

public record VerifiedCustomerMessage(
        string CustomerId,
        string FullName,
        string Email,
        DateTime RegisteredAt
    );