using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MvcRoute.Controllers
{
    public class RouteController : Controller
    {

      public ActionResult Test()
      {
        var builder = new StringBuilder();
        foreach (var d in RouteData.Values)
        {
          builder.Append(
            String.Format("{0}：{1}<br />", d.Key, d.Value));
        }
        return Content(builder.ToString());
      }

        public ActionResult Index()
        {
            return View();
        }
    }
}