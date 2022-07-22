using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Tracing.DataAccess.Models;

namespace Tracing.DataAccess.Dtos
{
    public class OwnerReadDto
    {
        [JsonProperty(PropertyName = "ownerid")]
        public Guid OwnerId { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        [EmailAddress]
        public string email { get; set; } = string.Empty;
        
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
