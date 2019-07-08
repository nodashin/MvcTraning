using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcView.Controllers
{
    public class LinkController : Controller
    {
        // GET: Link
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Link()
        {
            return View();
        }

        public ActionResult Encode()
        {
            return View();
        }

        public ActionResult Raw()
        {
            return View();
        }
    }
}