using MvcRoute.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MvcRoute.Controllers
{
    public class AttributeController : Controller
    {
      private MvcRouteContext db = new MvcRouteContext();

      [Route("Blog/{day}/{month}/{year}")]
      //[Route("Blog/{day:range(1, 31)}/{month:range(1, 12)}/{year:min(2010)}")]
      //[Route("Blog/{day:min(1):max(31)}/{month:range(1, 12)}/{year:min(2010)}")]
      public ActionResult Show(int day, int month, int year)
      {
          var builder = new StringBuilder();
          foreach (var d in RouteData.Values)
          {
            builder.Append(
              String.Format("{0}：{1}<br />", d.Key, d.Value));
          }
          return Content(builder.ToString());
        }

        //[Route("Blog/{day}/{month}/{year}", Name = "BlogRoute")]
        public ActionResult Show2(int day, int month, int year)
        {
          return View();
        }


        [Route("Attr/Articles/{category?}")]
        public ActionResult ShowByCategory(string category)
        {
          var list = from a in db.Articles
                     select a;
          if (category != null)
          {
            var c = (CategoryEnum)Enum.Parse(typeof(CategoryEnum), category);
            list = list.Where(a => a.Category == c);
          }
          return View(list);
        }

        [Route("Def/Articles/{category=Cloud}")]
        public ActionResult ShowByCategory2(string category)
        {
          var c = (CategoryEnum)Enum.Parse(typeof(CategoryEnum), category);
          var list = from a in db.Articles
                     where (a.Category == c)
                     select a;
          return View("ShowByCategory", list);
        }



        [Route("Route/{category:inArray(Database,Program,Cloud)}")]
        public ActionResult RouteSample(String category)
        {
          return Content("カテゴリー： " + category);
        }
    }
}