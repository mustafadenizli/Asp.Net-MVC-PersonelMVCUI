using PersonelMVCUI.App_Start;
using PersonelMVCUI.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PersonelMVCUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //authorize işlemi için uygulamamıza bu kodu yazdık.
            //bunun haricinde tek eklememiz gerekek login'de [AllowAnonymous] komutunu uygulamak.
            GlobalFilters.Filters.Add(new AuthorizeAttribute());
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //loglama için elmah
            GlobalFilters.Filters.Add(new ElmahExceptionFilter());
            //tüm projedeki controller'a filtre uygulama error attribütu uygulandı. hata gelirse bizi notfound'a yönlendirecek.
            GlobalFilters.Filters.Add(new HandleErrorAttribute());
        }
    }
}
