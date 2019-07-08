using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcController.Extensions;

namespace MvcController.Controllers
{
    public class SelectorController : Controller
    {
        // GET: Selector
        [Referre(true)]
        public ActionResult Index()
        {
            return Content("アクセスに成功しています。");
        }

        [MyAction]
        public ActionResult HogeAction()
        {
            return Content("正しく呼び出されました");
        }
    }
}