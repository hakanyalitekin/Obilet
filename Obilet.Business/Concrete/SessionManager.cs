using Newtonsoft.Json;
using Obilet.Business.Abstract;
using Obilet.Entities;
using Obilet.Entities.Concrete.Session;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Obilet.Business.Concrete
{
    public class SessionManager : ISessionService
    {
        private IRestApiService _restApiService;
        ///Todo: Gelen session ve device ıd burada cookie de tutulacak ve kontrol edilecek.
        public SessionManager(IRestApiService restApiService)
        {
            _restApiService = restApiService;
        }
        public Result GetSession()
        {
         
            Session session = new Session(){Type = 1, Connection = new Connection { IpAddress = "145.214.41.21", Port = "5117" }, Browser = new Browser { Name = "Chrome", Version = "47.0.0.12" }};
          
            return JsonConvert.DeserializeObject<Result>(_restApiService.Post<Session>(Constant.GetSession, session));

        }
    }
}
