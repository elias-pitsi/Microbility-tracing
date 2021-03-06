using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracing.DataAccess.Models
{
    public class ComponentsHistory
    {
        [JsonProperty(PropertyName = "compid")]
        public Guid CompId { get; set; } = Guid.NewGuid();
        public string ComponentName { get; set; } = string.Empty;
        public Owner? Owner { get; set; } 
        public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.Now;

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
