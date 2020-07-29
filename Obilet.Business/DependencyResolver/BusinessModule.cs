using Ninject.Modules;
using Obilet.Business.Abstract;
using Obilet.Business.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obilet.Business.DependencyResolver
{
    public class BusinessModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IBusLocationService>().To<BusLocationManager>().InSingletonScope();
            Bind<ICookieService>().To<CookieManager>().InSingletonScope();
            Bind<IRestApiService>().To<RestApiManager>().InSingletonScope();
            Bind<ISessionService>().To<SessionManager>().InSingletonScope();

            /*
             “BusinessModule” adlı class’ımızı “NinjectModule” abstract class’ından implemente ederek Load methodunu override ediyoruz. 
            Load methodumuz içerisinde “IProductService” ile “ProductManager” ‘ı “IProductDal” ile de “EfProductDal” ‘ı birbirine bağlıyoruz.
            Yani “IProductService” talebinde bulunulursa “ProductManager” instance’nı oluştur eğer
            “IProductDal” talebinde bulunulursa ise “EfProductDal” instance’nı oluştur diyoruz. 
            InSingletonScope() methodu ile de bu nesnelerin tek bir defa üretilmesini sağlıyoruz.
            */
        }
    }
}
