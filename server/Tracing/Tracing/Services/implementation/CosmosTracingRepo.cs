using Microsoft.EntityFrameworkCore;
using Tracing.DataAccess.DataContext;
using Tracing.DataAccess.Models;
using Tracing.Services.interfaces;

namespace Tracing.Services.implementation
{
    public class CosmosTracingRepo : ITracingRepo
    {
        private readonly TracingContext _dbContext;
        public CosmosTracingRepo(TracingContext context)
        {
            _dbContext = context;
            _dbContext.Database.EnsureCreated();
        }

        public IEnumerable<Owner> GetAll()
        {
            var data =  _dbContext.Owners.ToList();
            return data;
        }

        public Owner GetOwner(Guid ownerID)
        {
            var owner = _dbContext.Owners.FirstOrDefault(p => p.OwnerId == ownerID);

            return owner;
        }
        
        /// To be Correct
        public void CreateOwner(Owner owner)
        {
             _dbContext.Owners.Add(owner);
        }
        
    }
}
