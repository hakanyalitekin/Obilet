using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obilet.Entities.Concrete
{
    public class BusJourneyResult
    {
        public DeviceSession DeviceSession { get; set; }
        public DateTime Date { get; set; }
    }

    public class DeviceSession
    {
        public string SessionId { get; set; }
        public string DeviceId { get; set; }
    }

    public class JourneyData
    {
        public int OriginId { get; set; }
        public int DestinationId { get; set; }
        public DateTime DepartureDate { get; set; }
    }
}
