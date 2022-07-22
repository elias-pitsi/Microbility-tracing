using Tracing.Services.interfaces;

namespace Tracing.Services.implementation;

public class OwnerRegistration : IOwnerRegistration
{
    public AuthenticationResult Register(string firName, string lastName,string email, string password)
    {
        return new AuthenticationResult(
            Guid.NewGuid(), 
            firName,
            lastName, 
            email, 
            "token");
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