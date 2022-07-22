namespace Tracing.Services.interfaces;

public interface IJwtTokenGenerator
{
    string GenerateToken(Guid userId, string firstName, string LastName); 
}