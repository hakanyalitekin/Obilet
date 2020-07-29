using Newtonsoft.Json;
using Obilet.Entities.Concrete.Session;
using System;

namespace Obilet.Entities.Concrete
{
    public class BaseEntity
    {
        [JsonProperty("date")]
        public DateTime Date { get; set; } = DateTime.Now;

        [JsonProperty("language")]
        public string Language { get; set; } = "tr-TR";

        [JsonProperty("device-session")]
        public DeviceSession DeviceSession { get; set; }
    }
}
