using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcRoute.Models;

namespace MvcRoute.Controllers
{
    public class AttributeController : Controller
    {
        private MvcRouteContext db = new MvcRouteContext();

        // GET: Attribute
        public ActionResult Index()
        {
            return View();
        }

        [Route("Blog/{day}/{month}/{year}")]
        public ActionResult Show(int day, int month, int year)
        {
            return View();
        }

        //[Route("Blog/{day:range(1,31)}/{month:range(1,12)}/{year:min(2010)}", Name ="BlogRoute")]
        [Route("Blog/{day:min(1):max(31)}/{month:range(1,12)}/{year:min(2010)}", Name = "BlogRoute")]
        public ActionResult Show2(int day, int month, int year)
        {
            return View();
        }

        [Route("Attr/Articles/{category?}")]
        public ActionResult ShowByCategory(string category)
        {
            //Articleテーブルの内容を全件取得
            var list = db.Articles.Select(a => a);

            //引数Categoruyが指定された場合、その値でデータをフィルタリング
            if (category != null)
            {
                //文字列をCategoryEnum型に変換
                var c = (CategoryEnum)Enum.Parse(typeof(CategoryEnum), category);
                list = list.Where(a => a.Category == c);
            }

            return View(list);
        }

        [Route("Def/Attr/Articles/{category=Cloud}")]
        public ActionResult ShowByCategory2(string category)
        {
            //文字列をCategoryEnum型に変換
            var c = (CategoryEnum)Enum.Parse(typeof(CategoryEnum), category);
            var list = db.Articles.Where(a => a.Category == c);

            return View("ShowByCategory", list);
        }

        [Route("Route/{category:inArray(Database,Program,Cloud)}")]
        public ActionResult RouteSample(string category)
        {
            return Content("カテゴリー：" + category);
        }
    }
}