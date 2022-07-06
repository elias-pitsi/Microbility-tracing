using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracing.Infrastructure.Models
{
    public class Bike
    {
        [JsonProperty(PropertyName = "bikeid")]
        public Guid BikeId { get; set; }
        public List<Components> Components { get; set; } = new();
        public Guid OwnerId { get; set; } = Guid.NewGuid();

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
