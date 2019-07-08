using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcClient.Controllers
{
    public class LibraryController : Controller
    {
        // GET: Library
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Jquery()
        {
            return View();
        }

        public ActionResult Jquerui()
        {
            return View();
        }
    }
}