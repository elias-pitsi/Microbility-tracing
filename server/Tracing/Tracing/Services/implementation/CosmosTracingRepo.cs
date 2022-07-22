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
        
        public void CreateOwner(Owner owner)
        {
             _dbContext.Owners.Add(owner);
            _dbContext.SaveChanges();
        }

        public Owner GetOwnerByEmail(string email)
        {
            var owner = _dbContext.Owners.FirstOrDefault(u => u.email == email);
            return owner; 
        }

        public IEnumerable<Owner> GetOwnerItems()
        {
            return _dbContext.Owners.ToList();
        }
    }
}
