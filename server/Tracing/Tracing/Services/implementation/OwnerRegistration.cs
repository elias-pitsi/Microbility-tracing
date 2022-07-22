using Tracing.Services.interfaces;

namespace Tracing.Services.implementation;

public class OwnerRegistration : IOwnerRegistration
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public OwnerRegistration(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator; 
    }
    public AuthenticationResult Register(string firstName, string lastName,string email, string password)
    {
        var userId = Guid.NewGuid(); 
        var token = _jwtTokenGenerator.GenerateToken(userId, firstName, lastName);
        return new AuthenticationResult(
            userId, 
            firstName,
            lastName, 
            email, 
            token);
    }

    public AuthenticationResult Login(string email, string password)
    {
        return new AuthenticationResult(
            Guid.NewGuid(), 
            "firstaName",
            "lastName",
            email,
            "token"
            );

    }
}