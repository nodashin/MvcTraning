using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcView.Controllers
{
    public class RazorSyntaxController : Controller
    {
        // GET: RazorSyntax
        public ActionResult Index()
        {
            var model = new MvcView.Models.RazorSyntaxModel()
            {
                Title = "タイトル",
                Viewcount = 36452,
                Key = "Key",
            };

            return View(model);
        }
    }
}