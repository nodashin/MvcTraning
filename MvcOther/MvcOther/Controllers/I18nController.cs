using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOther.Controllers
{
    public class I18nController : Controller
    {
        // GET: I18n
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ResouceGlobal()
        {
            return View();
        }

        public ActionResult ResourceLoacl()
        {
            return View();
        }
    }
}