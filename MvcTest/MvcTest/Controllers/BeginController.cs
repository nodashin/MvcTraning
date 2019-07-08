using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTest.Controllers
{
    public class BeginController : Controller
    {
        // GET: Begin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Show()
        {
            ViewBag.Message = "こんにちは、世界！";
            return View();
        }

        public virtual ActionResult List()
        {
            throw new NotImplementedException();
        }
    }
}