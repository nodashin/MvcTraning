using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MvcController.Models;
using MvcController.Extensions;

namespace MvcController
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Database.SetInitializer<MvcControllerContext>(new MvcControllerInitializer());

            ValueProviderFactories.Factories.Add(new HttpCookieValueProviderFactory());
            //ModelBinders.Binders.Add(typeof(DateTime), new YMDBinder());
        }
    }
}
