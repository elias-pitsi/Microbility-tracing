using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracing.Infrastructure.Models
{
    public class Owner
    {
        [JsonProperty(PropertyName = "ownerid")]
        public Guid OwnerId { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        [EmailAddress]
        public string email { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public List<Components>? Components { get; set; }
        public List<Bike>? Bikes { get; set; }
        public int NumberOfBikes { get; set; }

        public Owner()
        {
            NumberOfBikes = Bikes.Count;
        } 
      
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
