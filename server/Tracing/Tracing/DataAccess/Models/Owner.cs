using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Tracing.DataAccess.Models
{
    public class Owner
    {
        [JsonProperty(PropertyName = "ownerid")]
        public Guid OwnerId { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        [EmailAddress]
        public string email { get; set; } = string.Empty;
        
        public string Password { get; set; } = String.Empty;
       
        public List<Bike>? Bikes { get; set; } = new List<Bike>();

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
