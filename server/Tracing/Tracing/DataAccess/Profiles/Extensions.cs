using Tracing.DataAccess.Dtos;
using Tracing.DataAccess.Models;

namespace Tracing.DataAccess.Profiles;

public static class Extensions
{
    public static OwnerReadDto AsDto(this Owner owner)
    {
        return new OwnerReadDto
        {
            OwnerId = owner.OwnerId,
            Name = owner.Name,
            Surname = owner.Surname,
            email = owner.email
        }; 
    }
}