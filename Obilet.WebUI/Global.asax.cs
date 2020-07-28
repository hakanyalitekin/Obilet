using Obilet.Business.DependencyResolver;
using Obilet.WebUI.Infrastructure.Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Obilet.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            /*
          “NinjectControllerFactory” class’ýný oluþtururken conctructor’ýnda bir “NinjectModule” almasýný belirtmiþtik.
           Ýþ katmanýmýzda oluþturmuþ olduðumuz “BusinessModule” ‘ý burada veriyoruz.
      */
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(new BusinessModule()));

        }
    }
}
