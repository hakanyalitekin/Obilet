using Obilet.Entities.Concrete.BusJourney;
using Obilet.Entities.Concrete.BusLocation;
using Obilet.Entities.Concrete.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obilet.Business.Abstract
{
    public interface IBusLocationService
    {
       List<BusLocationData> GetBusLocations(string session);

     
    }
}
