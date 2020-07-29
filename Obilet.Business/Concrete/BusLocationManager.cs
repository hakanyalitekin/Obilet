using Newtonsoft.Json;
using Obilet.Business.Abstract;
using Obilet.Entities.Concrete;
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
        public BusLocationManager(IRestApiService restApiService)
        {
            _restApiService = restApiService;
        }

    }
}



