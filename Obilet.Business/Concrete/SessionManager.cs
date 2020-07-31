using Newtonsoft.Json;
using Obilet.Business.Abstract;
using Obilet.Entities;
using Obilet.Entities.Concrete.Session;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Obilet.Business.Concrete
{
    public class SessionManager : ISessionService
    {
        private IRestApiService _restApiService;
        HttpBrowserCapabilities browser = HttpContext.Current.Request.Browser;
        public SessionManager(IRestApiService restApiService)
        {
            _restApiService = restApiService;
        }
        public Result GetSession()
        {
            string publicIp = new WebClient().DownloadString("https://checkip.amazonaws.com/").Trim();
            try
            {
                Session session = new Session()
                {
                    Type = 1,
                    Connection = new Connection { IpAddress = publicIp, Port = "5117" },
                    Browser = new Browser { Name = browser.Browser, Version = browser.Version }
                };

                return JsonConvert.DeserializeObject<Result>(_restApiService.Post<Session>(Constant.GetSession, session));
            }
            catch (Exception)
            {
                return null;
            }


        }

    }
}
