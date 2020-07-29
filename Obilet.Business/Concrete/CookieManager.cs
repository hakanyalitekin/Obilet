using Obilet.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Obilet.Business.Concrete
{
    public class CookieManager : ICookieService
    {
        public void CookieCreate(string cookiename, string value)
        {
            HttpCookie Cookie = null;
            if (HttpContext.Current.Response.Cookies[cookiename] != null)
            {
                HttpContext.Current.Request.Cookies.Remove(cookiename);
                HttpContext.Current.Response.Cookies[cookiename].Value = value;

                Cookie = HttpContext.Current.Response.Cookies[cookiename];
            }
            else
            {
                //Yoksa oluşturuyoruz.
                Cookie = new HttpCookie("OrnekCookie");
                Cookie.Expires = DateTime.Now.AddDays(10);
                Cookie[cookiename] = value;
            }
            HttpContext.Current.Response.Cookies.Add(Cookie);
        }
        public HttpCookie CookieGet(string cookiename)
        {
            if (HttpContext.Current.Request.Cookies[cookiename] != null)
                return HttpContext.Current.Request.Cookies[cookiename];
            else
                return null;
        }

        public void CookieDelete(string cookiename)
        {

            HttpContext.Current.Response.Cookies[cookiename].Expires = DateTime.Now.AddYears(-1);

            HttpContext.Current.Request.Cookies.Remove(cookiename);

        }
 
        public void ExpireAllCookies()
        {
            if (HttpContext.Current != null)
            {
                int cookieCount = HttpContext.Current.Request.Cookies.Count;
                for (var i = 0; i < cookieCount; i++)
                {
                    var cookie = HttpContext.Current.Request.Cookies[i];
                    if (cookie != null)
                    {
                        var expiredCookie = new HttpCookie(cookie.Name)
                        {
                            Expires = DateTime.Now.AddDays(-1),
                            Domain = cookie.Domain
                        };
                        HttpContext.Current.Response.Cookies.Add(expiredCookie); // overwrite it
                    }
                }

                // clear cookies server side
                HttpContext.Current.Request.Cookies.Clear();
            }
        }
    }
}
