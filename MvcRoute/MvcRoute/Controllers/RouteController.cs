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
        // GET: Route
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Test()
        {
            var builder = new StringBuilder();
            //すべてのルートパラメーターを走査
            foreach (var d in RouteData.Values)
            {
                //「キー名：値<br />の形式でパラメータを整形
                builder.Append(string.Format("{0}:{1}<br />", d.Key, d.Value));
            }

            return Content(builder.ToString());
        }
    }
}