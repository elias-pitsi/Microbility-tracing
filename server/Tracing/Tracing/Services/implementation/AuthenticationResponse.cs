namespace Tracing.Services.implementation;

public record AuthenticationResponse(
    Guid Id,
    string FirstName, 
    string LastName, 
    string Email, 
    string Token);