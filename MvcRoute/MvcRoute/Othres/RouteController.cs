using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcRoute.Othres
{
    public class RouteController : Controller
    {
        // GET: Route
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Test()
        {
            return Content("Others 名前空間です。");
        }
    }
}