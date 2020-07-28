using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obilet.Entities.Concrete
{
    public class SessionResult
    {
        public string Status { get; set; }
        public SessionData Data { get; set; }
    }

    public class SessionData
    {
        public string SessionId { get; set; }
        public string DeviceId { get; set; }
    }
}
