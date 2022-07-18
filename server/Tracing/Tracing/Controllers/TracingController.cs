using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tracing.DataAccess.Models;
using Tracing.Repositories.interfaces;

namespace Tracing.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TracingController : ControllerBase
    {
        private readonly ITracingRepo _context;
        private readonly Mapper _mapper;

        public TracingController(ITracingRepo context, Mapper mapper)
        {
            _context = context;
            //_context.Database.EnsureCreated();
            _mapper = mapper;
        }

      
    }
}
