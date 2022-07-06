using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracing.Infrastructure.Models
{
    public class Components
    {
        public Guid CompId { get; set; } = Guid.NewGuid();
        public string ComponentName { get; set; } = string.Empty;
        public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.Now;
    }
}
