using MvcController.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcController.Controllers
{
    //[Authorize] 
    public class FilterController : Controller
    {
      //[HandleError]
        //[OutputCache(Duration = 600)]
        public ActionResult Hello()
        {
            return View();
        }

      public ActionResult Fragment()
      {
        return View();
      }

      [ChildActionOnly]
      [OutputCache(Duration = 120)]
      public ActionResult FragmentChild()
      {
        return PartialView("_FragmentChild");
      }

      //[HandleError(View = "ErrorSpare")]
      public ActionResult Exception()
      {
        throw new Exception("致命的なエラーです。");
      }

      public ActionResult Exception2()
      {
        throw new ArgumentException("致命的なエラーです。");
      }

      [TimeLimit("2014/12/01", "2014/12/31")]
      public ActionResult Limit()
      {
        return Content("有効期間中です。");
      }

      [LoggingError]
      public ActionResult Log()
      {
        throw new Exception("例外が発生しました！");
      }

      [Logging]
      public ActionResult AccessLog()
      {
        return Content("ログを記録しました。");
      }

      [CheckOrder(Order = 1)]
      [CheckOrder(Order = 2)]
      [CheckOrder(Order = 3)]
      public ActionResult Order()
      {
        Response.Write("<p>ActionMethod</p>");
        return Content("<p>ActionResult</p>", "text/html");
      }


    }
}