using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOther.Controllers
{
    public class I18nController : Controller
    {
      public ActionResult ResourceGlobal()
        {
            return View();
        }

      public ActionResult ResourceLocal()
      {
        return View();
      }

      //public ActionResult Helper()
      //{
      //  return View();
      //}
    }
}