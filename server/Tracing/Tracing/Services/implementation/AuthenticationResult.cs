namespace Tracing.Services.implementation;

public record AuthenticationResult(
    Guid Id, 
    string FirstName, 
    string LastName, 
    string Email, 
    string Token);