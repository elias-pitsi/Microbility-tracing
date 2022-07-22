using Microsoft.AspNetCore.Mvc;
using Tracing.DataAccess.Models;

namespace Tracing.Services.interfaces
{
    public interface ITracingRepo
    {
      public  IEnumerable<Owner> GetAll();
      Owner GetOwner(Guid ownerID);
     void CreateOwner(Owner owner); 
    }
}
