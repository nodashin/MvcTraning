using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcView.Controllers
{
    public class LayoutController : Controller
    {
      public ActionResult Layout()
      {
        return View();
      }

      public ActionResult Layout2()
      {
        return View();
      }

      public ActionResult Layout3()
      {
        return View("Layout3", "_ActionLayout");
      }
    }
}