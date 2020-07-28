using Obilet.Business.Abstract;
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

        public HomeController(IBusLocationService busLocationService)
        {
            _busLocationService = busLocationService;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FindJourney()
        {
            return View();
        }
    }
}