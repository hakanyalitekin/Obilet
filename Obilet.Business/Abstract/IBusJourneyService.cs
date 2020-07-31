using Obilet.Entities.Concrete.BusJourney;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obilet.Business.Abstract
{
    public interface IBusJourneyService
    {
        List<BusJourneyData> GetBusJourneys(Data data, string session);
    }
}
