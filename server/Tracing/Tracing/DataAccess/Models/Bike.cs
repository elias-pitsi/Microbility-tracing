using Newtonsoft.Json;

namespace Tracing.DataAccess.Models;

public class Bike
{
    [JsonProperty(PropertyName = "bikeid")]
    public Guid BikeId { get; set; } = Guid.NewGuid();
    public List<ComponentDetails> Components { get; set; } = new();

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}

