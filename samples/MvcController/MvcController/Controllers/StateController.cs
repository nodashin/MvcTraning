using System;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

namespace MvcController.Controllers
{
    //[SessionState(SessionStateBehavior.Disabled)]
    public class StateController : Controller
    {
      public ActionResult Cookie()
      {
        if (Request.Cookies["email"] != null) 
        {         
          ViewBag.Email = Request.Cookies["email"].Value;
        }
        return View();
      }

      [HttpPost]
      public ActionResult Cookie(string email)
      {
        Response.AppendCookie(new HttpCookie("email")
        {
          Value = email,
          Expires = DateTime.Now.AddDays(7),
          HttpOnly = true
        });
        return RedirectToAction("Cookie");
      }

      public ActionResult SessionRecord()
      {
        ViewBag.Email = Session["email"];
        return View();
      }

      [HttpPost]
      public ActionResult SessionRecord(string email)
      {
        Session["email"] = email;
        return RedirectToAction("SessionRecord");
      }

    }
}