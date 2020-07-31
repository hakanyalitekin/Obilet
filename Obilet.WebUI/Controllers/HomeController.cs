using Newtonsoft.Json;
using Obilet.Business.Abstract;
using Obilet.Entities;
using Obilet.Entities.Concrete;
using Obilet.Entities.Concrete.BusJourney;
using Obilet.Entities.Concrete.BusLocation;
using Obilet.Entities.Concrete.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Obilet.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IBusLocationService _busLocationService;
        private IBusJourneyService _busJourneyService;
        private ICookieService _cookieService;
        private ISessionService _sessionService;
        string sessionFromCookie;
        public HomeController(IBusLocationService busLocationService, ICookieService cookieService, ISessionService sessionService, IBusJourneyService busJourneyService)
        {
            _busLocationService = busLocationService;
            _cookieService = cookieService;
            _sessionService = sessionService;
            _busJourneyService = busJourneyService;

            ///Todo:Burası kontrol edilecek.
            _cookieService.CookieCreate(Constant.Session, JsonConvert.SerializeObject(_sessionService.GetSession().Data));

            if (string.IsNullOrEmpty(_cookieService.CookieGet(Constant.Session).Value))
            {
                _cookieService.CookieCreate(Constant.Session, JsonConvert.SerializeObject(_sessionService.GetSession().Data));
            }
            else
            {
                sessionFromCookie = _cookieService.CookieGet(Constant.Session).Value;
            }
        }

        public ActionResult Index()
        {
            List<BusLocationData> busLocationData = _busLocationService.GetBusLocations(sessionFromCookie);
            List<SelectListItem> busLocationList = new List<SelectListItem>();

            foreach (BusLocationData busLocation in busLocationData)
            {
                busLocationList.Add(new SelectListItem { Text = busLocation.Name, Value = busLocation.Id.ToString() });
            }

            ViewBag.BusLocationList = new SelectList(busLocationList, "Value", "Text");

            return View();
        }

        public ActionResult FindJourney(int origin, int destination, DateTime departureDate)
        {
            Data data = new Data() { OriginId = origin, DestinationId = destination, DepartureDate = departureDate };

            List<BusJourneyData> busLocationDatas = _busJourneyService.GetBusJourneys(data, sessionFromCookie);

            return View(busLocationDatas);
        }
    }
}