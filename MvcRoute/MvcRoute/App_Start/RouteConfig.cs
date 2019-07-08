using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Routing;
using System.Web.Routing;
using MvcRoute.Extensions;

namespace MvcRoute
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var resolver = new DefaultInlineConstraintResolver();
            resolver.ConstraintMap.Add("inArray", typeof(InArrayConstraint));

            routes.MapMvcAttributeRoutes(resolver); //属性ルーティング有効化

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.IgnoreRoute("Blog/{day}/{month}/2015");

            routes.MapRoute(
                name: "MyRoot",                   //ルート名
                url: "Blog/{day}/{month}/{year}", //URIパターン
                defaults: new
                {
                    controller = "Route", //コントローラー名
                    action = "Test",      //アクション名
                    day = DateTime.Now.Day,
                    month = DateTime.Now.Month,
                    year = DateTime.Now.Year
                },  //デフォルト値
                constraints: new
                {
                    day = @"\d{1,2}",
                    month = @"\d{1,2}",
                    year = @"\d{4}",
                    verbs = new HttpMethodConstraint("GET", "POST"),
                    time = new TimeLimitConstraint(new DateTime(2018, 6, 7), new DateTime(2018, 6, 8))
                }, //制約条件
                namespaces: new[] { "MvcRoute.Controllers" } //名前空間
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
