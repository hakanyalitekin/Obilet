using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Obilet.Business.Abstract
{
    public interface ICookieService
    {
        void CookieCreate(string cookiename, string value);
        HttpCookie CookieGet(string cookiename);
        void CookieDelete(string cookiename);
        void ExpireAllCookies();
    }
}
