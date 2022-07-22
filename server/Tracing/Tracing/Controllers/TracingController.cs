using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tracing.DataAccess.Dtos;
using Tracing.DataAccess.Models;
using Tracing.DataAccess.Profiles;
using Tracing.Services.interfaces;

namespace Tracing.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TracingController : ControllerBase
    {
        private readonly ITracingRepo _context;

        public TracingController(ITracingRepo context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<OwnerReadDto>> GetAllOwner()
        {
            var item = _context.GetAll().Select(item => item.AsDto()); 

            if (item != null)
            {
                return Ok(item);
            }

            return NotFound("Nothing was found");
        }

        [HttpGet("{ownerID}")]
        public ActionResult<OwnerReadDto> GetOwnerDetails(Guid ownerID)
        {
            var owner = _context.GetOwner(ownerID);

            if (owner is null) return NotFound();
            return Ok(owner.AsDto());
        }

        [HttpPost]
        public ActionResult<OwnerReadDto> CreateOwner(CreatedOwnerDto created)
        {
            Owner owner = new()
            {
                OwnerId = Guid.NewGuid(),
                Name = created.Name, 
                Surname = created.Surname, 
                email = created.email
            };
            
            _context.CreateOwner(owner);

            return CreatedAtAction(nameof(GetAllOwner), new { OwnerId = created.OwnerId }, owner.AsDto());
        }
    }
}
