using Tracing.DataAccess.Models;
using Tracing.Services.interfaces;

namespace Tracing.Services.implementation;

public class OwnerRegistration : IOwnerRegistration
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly ITracingRepo _ownerTracingRepo;

    public OwnerRegistration(IJwtTokenGenerator jwtTokenGenerator, ITracingRepo ownerTracingRepo)
    {
        _jwtTokenGenerator = jwtTokenGenerator; 
        _ownerTracingRepo = ownerTracingRepo;
    }

    public AuthenticationResult Register(string firstName, string lastName,string email, string password)
    {
        // Validate the user doesn't exist 
        if (_ownerTracingRepo.GetOwnerByEmail(email) is not null)
        {
            // To be Implemented 
            throw new Exception("User with given email already exists"); 
        }
        
        var owner = new Owner()
        {
            Name = firstName,
            Surname = lastName,
            email = email,
            Password = password
        }; 
        
        _ownerTracingRepo.CreateOwner(owner);
        
        var token = _jwtTokenGenerator.GenerateToken(owner);
        return new AuthenticationResult(
            owner, 
            token);
    }

    public AuthenticationResult Login(string email, string password)
    {
        if (_ownerTracingRepo.GetOwnerByEmail(email) is not Owner owner)
        {
            throw new Exception("User with given email does not exist");
        }
        
        if (owner.Password != password)
        {
            throw new Exception("Invalid password");
        }
        
        var token = _jwtTokenGenerator.GenerateToken(owner);
        return new AuthenticationResult(
            owner, 
            token);
    }
}