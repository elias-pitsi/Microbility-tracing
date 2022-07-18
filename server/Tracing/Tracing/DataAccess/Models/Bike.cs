using Newtonsoft.Json;

namespace Tracing.DataAccess.Models;

public class Bike
{
    [JsonProperty(PropertyName = "bikeid")]
    public Guid BikeId { get; set; }
    public List<Component> Components { get; set; } = new();

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}

