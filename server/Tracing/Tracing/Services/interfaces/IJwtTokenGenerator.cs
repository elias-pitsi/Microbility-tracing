using Tracing.DataAccess.Models;

namespace Tracing.Services.interfaces;

public interface IJwtTokenGenerator
{
    string GenerateToken(Owner owner); 
}