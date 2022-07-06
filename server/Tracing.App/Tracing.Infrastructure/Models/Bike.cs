using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracing.Infrastructure.Models
{
    public class Bike
    {
        public Guid BikeId { get; set; }
        public Owner Owner { get; set; }
        public List<Components> Components { get; set; } = new(); 
    }
}
