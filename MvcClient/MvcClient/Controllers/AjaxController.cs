using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using MvcClient.Models;

namespace MvcClient.Controllers
{
    public class AjaxController : Controller
    {
        MvcClientContext db = new MvcClientContext();

        // GET: Ajax
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AjaxLink()
        {
            var list = EnumHelper.GetSelectList(typeof(CategoryEnum));
            return View(list);
        }

        public ActionResult AjaxSearch(CategoryEnum id)
        {
            if(Request.IsAjaxRequest())
            {
                //指定されたカテゴリに記事だけを抽出
                var articles = db.Articles.Where(a => a.Category == id).OrderBy(a => a.Published);

                return PartialView("_AjaxSearch", articles);
            }

            return Content("Ajax通信以外のアクセスはできません。");
        }
    }
}