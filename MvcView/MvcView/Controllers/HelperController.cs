using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcView.Models;

namespace MvcView.Controllers
{
    public class HelperController : Controller
    {
        private MvcViewContext db = new MvcViewContext();

        // GET: Helper
        public ActionResult Custom()
        {
            return View();
        }

        public ActionResult RadioList(int? id)
        {
            if (id == null) id = 1;
            Member member = db.Members.Find(id);
            ViewBag.Names = db.Members.Select(m => new SelectListItem{ Value = m.Name, Text = m.Name });

            return View(member);
        }

        public ActionResult RazorHelper()
        {
            return View();
        }

        public ActionResult FailHelper()
        {
            return View();
        }

        public ActionResult Inline()
        {
            return View();
        }
    }
}