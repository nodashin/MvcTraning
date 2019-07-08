using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOther.Controllers
{
    public class OtherController : Controller
    {

      [Authorize(Roles = "Admin")]
      public ActionResult RoleAuth()
      {
        return Content("管理者のページです。");
      }
       // GET: Other
        public ActionResult Index()
        {
            return View();
        }
    }
}