using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obilet.Entities.Concrete.BusLocation
{
    public class BusLocationData
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("parent-id")]
        public int ParentId { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("rank")]
        public int? Rank { get; set; }

        [JsonProperty("keywords")]
        public string Keywords { get; set; }
    }
}
