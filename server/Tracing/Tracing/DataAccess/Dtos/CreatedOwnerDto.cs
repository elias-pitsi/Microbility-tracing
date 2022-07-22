using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Tracing.DataAccess.Dtos;

public class CreatedOwnerDto
{
    [JsonProperty(PropertyName = "ownerid")]
    public Guid OwnerId { get; set; } 
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    [EmailAddress]
    public string email { get; set; } = string.Empty;
        
    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}