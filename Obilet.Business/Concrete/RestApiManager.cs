using Newtonsoft.Json;
using Obilet.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Obilet.Business.Concrete
{
    public class RestApiManager:IRestApiService
    {
        private string _url = "https://v2-api.obilet.com/api/";

        public string Post<T>(string Url, T model)
        {
            using (var client = new HttpClient())
            {
                client.Timeout = new TimeSpan(0, 0, 360); //kill after 30 seconds
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //if (HttpContext.Current.Session["Authorization"] != null)
                    //client.DefaultRequestHeaders.Add("Authorization", HttpContext.Current.Session["Token"].ToString());
                    client.DefaultRequestHeaders.Add("Authorization", "Basic ZEdocGMybHpZV0p5WVc1a2JtVjNZbWx1");

                JsonSerializerSettings microsoftDateFormatSettings = new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat,
                };

                StringContent content;

                content = new StringContent(JsonConvert.SerializeObject(model, microsoftDateFormatSettings), Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(_url + Url, content).Result;

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception("Web Call Error," +
                                        Environment.NewLine + Environment.NewLine +
                                        "Status Code: " + response.StatusCode +
                                        Environment.NewLine +
                                        "Reason Phrase: " + response.ReasonPhrase + " Adress:" + _url + Url);
                }
                var responseString = response.Content.ReadAsStringAsync().Result;

                return responseString;
            }

        }


    }

}
