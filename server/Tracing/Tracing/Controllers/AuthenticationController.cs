using Microsoft.AspNetCore.Mvc;
using Tracing.Services.implementation;
using Tracing.Services.interfaces;

namespace Tracing.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IOwnerRegistration _register;

    public AuthenticationController(IOwnerRegistration register)
    {
        _register = register;
    }
    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var authResult = _register.Register(
            request.FirstName, 
            request.LastName, 
            request.Email, 
            request.Password);
        var response = new AuthenticationResponse(
            authResult.Id, 
            authResult.FirstName, 
            authResult.LastName, 
            authResult.Email, 
            authResult.Token);
        
        return Ok(response);
    }
    
    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var authResult = _register.Login(
            request.Email, 
            request.Password);
        var response = new AuthenticationResponse(
            authResult.Id, 
            authResult.FirstName, 
            authResult.LastName, 
            authResult.Email, 
            authResult.Token);

        return Ok(response);
    }
}
