namespace CustomerRegistrationVerification.Core.Constants;

public static class EmailTemplates
{
    public const string Subject = "Your account is verified";

    public const string Body = "Hi {FullName},\n\nThank you for registering with us.\nYour registration has been successfully verified at: {RegisteredAt}\n\nBest regards,\nCustomer Support Team";
}