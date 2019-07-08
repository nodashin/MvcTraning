using MvcView.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcView.Controllers
{

  public class HelperController : Controller
  {
    private MvcViewContext db = new MvcViewContext();

    public ActionResult Custom()
    {
      return View();
    }

    public ActionResult RadioList(int? id)
    {
      Member member = db.Members.Find(id);
      ViewBag.Names = from m in db.Members
        select new SelectListItem { Value = m.Name, Text = m.Name };
      return View(member);
    }

    public ActionResult RazorHelper()
    {
      return View();
    }

    public ActionResult inline()
    {
      return View();
    }
  }
}