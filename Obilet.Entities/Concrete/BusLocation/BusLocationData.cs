using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Obilet.Entities.Concrete.BusLocation
{
    public class BusLocationData
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("parent-id")]
        public int ParentId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("rank")]
        public int? Rank { get; set; }

        [JsonProperty("keywords")]
        public string Keywords { get; set; }
    }
}
