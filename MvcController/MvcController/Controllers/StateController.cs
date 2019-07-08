using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcController.Controllers
{
    //[SessionState(System.Web.SessionState.SessionStateBehavior.Disabled)]
    public class StateController : Controller
    {
        // GET: State
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cookie()
        {
            if (Request.Cookies["email"] != null)
            {
                //ビュー変数Emailにクッキーemailの値を設定
                ViewBag.Email = Request.Cookies["email"].Value;
            }
            return View();
        }

        [HttpPost]
        public ActionResult Cookie(string email)
        {
            //クッキーemailを保存(有効期限は7日間)
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