using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcController.Extensions;

namespace MvcController.Controllers
{
    //[Authorize]
    public class FilterController : Controller
    {
        // GET: Filter
        public ActionResult Index()
        {
            return View();
        }

        [HandleError]
        [OutputCache(Duration =600)]
        public ActionResult Hello()
        {
            return View();
        }

        public ActionResult Exception()
        {
            throw new Exception("致命的なエラーです。");
        }

        public ActionResult Exception2()
        {
            throw new ArgumentException("致命的なエラーです。");
        }

        //親アクション
        public ActionResult Fragment()
        {
            return View();
        }

        //子アクション
        [ChildActionOnly]
        [OutputCache(Duration = 120)]
        public ActionResult FragmentChild()
        {
            return PartialView("_FragmentChild");
        }

        [TimeLimit("2017/06/07", "2017/06/08")]
        public ActionResult Limit()
        {
            return Content("有効期間内です。");
        }

        [LoggingError]
        public ActionResult Log()
        {
            throw new Exception("例外が発生しました");
        }

        [Logging]
        public ActionResult AccessLog()
        {
            return Content("ログを記録しました。");
        }

        [CheckOrder(Order =1)]
        [CheckOrder(Order = 2)]
        [CheckOrder(Order = 3)]
        public ActionResult Order()
        {
            Response.Write("<p><font color='red'>ActionMethod</font></p>");
            return Content("<p><font color='red'>ActionResut</font></p>", "text/html");
        }
    }
}