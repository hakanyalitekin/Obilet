using Newtonsoft.Json;
using Obilet.Business.Abstract;
using Obilet.Entities;
using Obilet.Entities.Concrete.BusJourney;
using Obilet.Entities.Concrete.Session;
using System.Collections.Generic;
using System.Linq;

namespace Obilet.Business.Concrete
{
    public class BusJourneyManager : IBusJourneyService
    {
        private IRestApiService _restApiService;

        public BusJourneyManager(IRestApiService restApiService)
        {
            _restApiService = restApiService;
        }
        public List<BusJourneyData> GetBusJourneys(Data data, string session)
        {
            try
            {
                SessionData sessionData = JsonConvert.DeserializeObject<SessionData>(session);

                BusJourney busJourney = new BusJourney()
                {
                    DeviceSession = new DeviceSession { DeviceId = sessionData.DeviceId, SessionId = sessionData.SessionId },
                    Data = new Data { OriginId = data.OriginId, DestinationId = data.DestinationId, DepartureDate = data.DepartureDate }
                };

                Result busJourneyResult = JsonConvert.DeserializeObject<Result>(_restApiService.Post<BusJourney>(Constant.GetBusJourneys, busJourney));

                return JsonConvert.DeserializeObject<List<BusJourneyData>>(busJourneyResult.Data.ToString()).ToList();
            }
            catch (System.Exception)
            {

                return null;
            }



        }
    }
}
