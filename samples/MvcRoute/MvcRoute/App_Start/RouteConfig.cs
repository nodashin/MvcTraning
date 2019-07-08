using MvcRoute.Extensions;
using System;
using System.Web.Mvc;
using System.Web.Mvc.Routing;
using System.Web.Routing;

namespace MvcRoute
{
  public class RouteConfig
  {
    public static void RegisterRoutes(RouteCollection routes)
    {
      //var resolver = new DefaultInlineConstraintResolver();
      //resolver.ConstraintMap.Add("inArray", typeof(InArrayConstraint));
      //routes.MapMvcAttributeRoutes(resolver);
      //routes.MapMvcAttributeRoutes();

      routes.MapRoute(
        name: "MyRoute",
        url: "Blog/{day}/{month}/{year}",
        defaults: new
        {
          controller = "Route",
          action = "Test",
          day = DateTime.Now.Day,
          month = DateTime.Now.Month,
          year = DateTime.Now.Year
        }
      );

      //routes.IgnoreRoute("Blog/{day}/{month}/2015");
      //routes.MapRoute(
      //  name: "MyRoute",
      //  url: "Blog/{day}/{month}/{year}",
      //  defaults: new
      //  {
      //    controller = "Route",
      //    action = "Test",
      //    day = DateTime.Now.Day,
      //    month = DateTime.Now.Month,
      //    year = DateTime.Now.Year
      //  },
      //  constraints: new
      //  {
      //    day = @"\d{1,2}",
      //    month = @"\d{1,2}",
      //    year = @"\d{4}",
      //    verbs = new HttpMethodConstraint("GET"),
      //    time = new TimeLimitConstraint(
      //      new DateTime(2014, 10, 1), new DateTime(2014, 10, 31))
      //  },
      //  namespaces: new[] { "MvcRoute.Controllers" }
      //);

      routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

      routes.MapRoute(
          name: "Default",
          url: "{controller}/{action}/{id}",
          defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
          namespaces: new[] { "MvcRoute.Controllers" }
      );


    }
  }
}
