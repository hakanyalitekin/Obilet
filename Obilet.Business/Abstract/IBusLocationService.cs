using Obilet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obilet.Business.Abstract
{
    public interface IBusLocationService
    {
        List<BusLocation> GetBusLocations();
    }
}
