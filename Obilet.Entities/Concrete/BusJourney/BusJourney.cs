using Newtonsoft.Json;
using System;

namespace Obilet.Entities.Concrete.BusJourney
{
    public class BusJourney : BaseEntity
    {
        [JsonProperty("data")]

        public Data Data { get; set; }
    }

    public class Data
    {

        [JsonProperty("origin-id")]
        public int OriginId { get; set; }

        [JsonProperty("destination-id")]
        public int DestinationId { get; set; }

        [JsonProperty("departure-date")]
        public DateTime DepartureDate { get; set; }
    }
}
