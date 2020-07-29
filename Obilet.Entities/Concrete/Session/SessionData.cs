using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obilet.Entities.Concrete.Session
{
    public class SessionData
    {
        [JsonProperty("session-id")]
        public string SessionId { get; set; }

        [JsonProperty("device-id")]
        public string DeviceId { get; set; }

        //[JsonProperty("affiliate")]
        //public string Affiliate { get; set; }

        [JsonProperty("device-type")]
        public int DeviceType { get; set; }
    }
}
