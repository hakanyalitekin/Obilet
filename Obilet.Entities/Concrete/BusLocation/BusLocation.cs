using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obilet.Entities.Concrete.BusLocation
{
    public class BusLocation
    {
        [JsonProperty("date")]
        public DateTime Date { get; set; } = DateTime.Now;

        [JsonProperty("language")]
        public string Language { get; set; } = "tr-TR";

        [JsonProperty("device-session")]
        public DeviceSession DeviceSession { get; set; }

    }
    public class DeviceSession
    {
        [JsonProperty("session-id")]
        public string SessionId { get; set; }

        [JsonProperty("device-id")]
        public string DeviceId{ get; set; }
    }
}
