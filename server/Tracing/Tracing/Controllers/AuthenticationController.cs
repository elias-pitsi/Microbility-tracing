using Microsoft.AspNetCore.Mvc;
using Tracing.DataAccess.Dtos;
using Tracing.DataAccess.Models;
using Tracing.Services.implementation;
using Tracing.Services.interfaces;

namespace Tracing.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IOwnerRegistration _register;
    private readonly ITracingRepo _repo;

    public AuthenticationController(IOwnerRegistration register, ITracingRepo context)
    {
        _register = register;
        _repo = context;
    }
    
    [HttpPost("register")]
    public IActionResult Register(OwnerReadDto request)
    {
        var authResult = _register.Register(
            request.Name, 
            request.Surname, 
            request.email, 
            request.Password);
        
        var response = new AuthenticationResponse(
            authResult.owner.OwnerId, 
            authResult.owner.Name, 
            authResult.owner.Surname, 
            authResult.owner.email, 
            authResult.Token);
        
        return Ok(response);
    }
    
    [HttpPost("login")]
    public IActionResult Login(OwnerReadDto request)
    {
        var authResult = _register.Login(
            request.email, 
            request.Password);
        
        var response = new AuthenticationResponse(
            authResult.owner.OwnerId, 
            authResult.owner.Name, 
            authResult.owner.Surname, 
            authResult.owner.email, 
            authResult.Token);

        return Ok(response);
    }

    [HttpGet]
    public IEnumerable<Owner> GetOwnerItems()
    {
        var items = _repo.GetOwnerItems();
        return items; 
    }

    [HttpPost]
    public IActionResult CreateOwner(Owner owner)
    {
        if (ModelState.IsValid)
        {
            _repo.CreateOwner(owner);
            return CreatedAtAction("GetByEmail", new { owner.OwnerId }, owner);
        }

        return new JsonResult("Something went wrong") { StatusCode = 500 };
    }

    [HttpGet("{email}")]
    public IActionResult GetByEmail(string email)
    {
        var owner = _repo.GetOwnerByEmail(email);
        return Ok(owner);
    }
}
