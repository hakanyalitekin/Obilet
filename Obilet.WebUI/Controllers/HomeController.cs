using Newtonsoft.Json;
using Obilet.Business.Abstract;
using Obilet.Entities.Concrete;
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
        private ICookieService _cookieService;
        private ISessionService _sessionService;

        public HomeController(IBusLocationService busLocationService, ICookieService cookieService, ISessionService sessionService)
        {
            _busLocationService = busLocationService;
            _cookieService = cookieService;
            _sessionService = sessionService;
        }

        public ActionResult Index()
        {
            List<BusLocationData> busLocationData = _busLocationService.GetBusLocations();

            List<SelectListItem> busLocationList = new List<SelectListItem>();
            foreach (BusLocationData busLocation in busLocationData)
            {
                busLocationList.Add(new SelectListItem { Text = busLocation.Name, Value = busLocation.Id.ToString() });
            }
            ViewBag.BusLocationList = new SelectList(busLocationList, "Value", "Text");

            return View();
        }

        public ActionResult FindJourney()
        {
            return View();
        }
    }
}