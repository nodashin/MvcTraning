using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcModel.Models;

namespace MvcModel.Controllers
{
    public class CommentController : Controller
    {
        private MvcModelContext db = new MvcModelContext();

        // GET: Comment
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Navigation(int? id)
        {
            if (id == null)
                id = 1;

            Comment comment = db.Comments.Find(id);
            return View(comment);
        }
    }
}