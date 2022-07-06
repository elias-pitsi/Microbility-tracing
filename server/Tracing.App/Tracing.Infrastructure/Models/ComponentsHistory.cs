using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracing.Infrastructure.Models
{
    public class ComponentsHistory
    {
        public int Id { get; set; }
        public Components? components { get; set; }
        public Bike? Bike { get; set; }
        public List<Owner> Owners { get; set; } = new();
    }
}
