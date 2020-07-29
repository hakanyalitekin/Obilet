using Newtonsoft.Json;
using Obilet.Business.Abstract;
using Obilet.Entities.Concrete.BusJourney;
using Obilet.Entities.Concrete.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obilet.Business.Concrete
{
    public class BusJourneyManager: IBusJourneyService
    {
        private IRestApiService _restApiService;
        private ISessionService _sessionService;

        public BusJourneyManager(IRestApiService restApiService, ISessionService sessionService)
        {
            _sessionService = sessionService;
            _restApiService = restApiService;
        }
        public List<BusJourneyData> GetBusJourneys(Data data)
        {
            SessionData sessionData = JsonConvert.DeserializeObject<SessionData>(_sessionService.GetSession().Data.ToString());

            BusJourney busJourney = new BusJourney()
            {
                DeviceSession = new DeviceSession
                {
                    DeviceId = sessionData.DeviceId,
                    SessionId = sessionData.SessionId
                },
                Data = new Data
                {
                    OriginId = data.OriginId,
                    DestinationId = data.DestinationId,
                    DepartureDate = data.DepartureDate
                }
            };

            Result busJourneyResult = JsonConvert.DeserializeObject<Result>(_restApiService.Post<BusJourney>("journey/getbusjourneys", busJourney));

            List<BusJourneyData> busJourneyList = JsonConvert.DeserializeObject<List<BusJourneyData>>(busJourneyResult.Data.ToString());
            return busJourneyList.Where(x => x.Journey.OriginalPrice < 100).Take(10).ToList();

        }
    }
}
