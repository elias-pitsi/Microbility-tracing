using Tracing.Services.implementation;

namespace Tracing.Services.interfaces;

public interface IOwnerRegistration
{
    AuthenticationResult Register(string firName, string lastName,string email, string password);
    AuthenticationResult Login(string email, string password);
}