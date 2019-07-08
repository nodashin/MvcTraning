using MvcView.Extensions;
using MvcView.Models;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.WebPages;

namespace MvcView
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //ViewEngines.Engines.Clear();
            //ViewEngines.Engines.Add(new WebFormViewEngine());
            //ViewEngines.Engines.Add(new RazorViewEngine());
            //ViewEngines.Engines.Add(new XslTransformViewEngine());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Database.SetInitializer<MvcViewContext>(new MvcViewInitializer());

            DisplayModeProvider.Instance.Modes.Insert(0,
              new DefaultDisplayMode("iPhone")
              {
                ContextCondition = (c =>
                    c.Request.UserAgent.IndexOf("iPhone") >= 0)
              });
        }
    }
}
