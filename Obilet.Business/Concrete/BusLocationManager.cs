using Newtonsoft.Json;
using Obilet.Business.Abstract;
using Obilet.Entities.Concrete;
using Obilet.Entities.Concrete.BusJourney;
using Obilet.Entities.Concrete.BusLocation;
using Obilet.Entities.Concrete.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obilet.Business.Concrete
{

    public class BusLocationManager : IBusLocationService
    {
        private IRestApiService _restApiService;
        private ISessionService _sessionService;
        public BusLocationManager(IRestApiService restApiService, ISessionService sessionService)
        {
            _sessionService = sessionService;
            _restApiService = restApiService;
        }

        public List<BusLocationData> GetBusLocations()
        {
            SessionData sessionData = JsonConvert.DeserializeObject<SessionData>(_sessionService.GetSession().Data.ToString());

            BusLocation busLocation = new BusLocation() { DeviceSession = new DeviceSession { DeviceId = sessionData.DeviceId, SessionId = sessionData.SessionId }};
         
            Result busLocationResult = JsonConvert.DeserializeObject<Result>(_restApiService.Post<BusLocation>("location/getbuslocations", busLocation));

            return JsonConvert.DeserializeObject<List<BusLocationData>>(busLocationResult.Data.ToString());

        }


    }
}



