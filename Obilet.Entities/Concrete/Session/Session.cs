using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obilet.Entities.Concrete.Session
{
    public class Session
    {
        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("connection")]
        public Connection Connection { get; set; }

        [JsonProperty("browser")]
        public Browser Browser { get; set; }
    }
    public class Connection
    {
        [JsonProperty("ip-address")]
        public string IpAddress { get; set; }

        [JsonProperty("port")]
        public string Port { get; set; }

    }

    public class Browser
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

    }

}



    //{
    //"type": 1,
    //"connection": {
    //    "ip-address": "145.214.41.21",
    //    "port": "5117"
    //},
    //"browser": {
    //    "name": "Chrome",
    //    "version": "47.0.0.12"
    //}
