using Newtonsoft.Json;
using Obilet.Business.Abstract;
using Obilet.Entities;
using Obilet.Entities.Concrete.BusLocation;
using Obilet.Entities.Concrete.Session;
using System.Collections.Generic;

namespace Obilet.Business.Concrete
{

    public class BusLocationManager : IBusLocationService
    {
        private IRestApiService _restApiService;

        public BusLocationManager(IRestApiService restApiService)
        {
            _restApiService = restApiService;
        }

        public List<BusLocationData> GetBusLocations(string session)
        {
            try
            {
                SessionData sessionData = JsonConvert.DeserializeObject<SessionData>(session);

                BusLocation busLocation = new BusLocation() { DeviceSession = new DeviceSession { DeviceId = sessionData.DeviceId, SessionId = sessionData.SessionId } };

                Result busLocationResult = JsonConvert.DeserializeObject<Result>(_restApiService.Post<BusLocation>(Constant.GetBusLocations, busLocation));

                return JsonConvert.DeserializeObject<List<BusLocationData>>(busLocationResult.Data.ToString());
            }
            catch (System.Exception)
            {

                return null;
            }

        }
    }
}



