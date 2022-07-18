using AutoMapper;
using Tracing.DataAccess.Dtos;
using Tracing.DataAccess.Models;

namespace Tracing.DataAccess.Profiles
{
    public class TracingProfile : Profile
    {
        public TracingProfile()
        {
            CreateMap<Owner, OwnerReadDto>(); 
        }
    }
}
