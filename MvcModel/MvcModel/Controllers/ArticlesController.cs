using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcModel.Models;

namespace MvcModel.Controllers
{
    public class ArticlesController : Controller
    {
        private MvcModelContext db = new MvcModelContext();

        // GET: Articles
        public ActionResult Index()
        {
            var articles = db.Database.SqlQuery<Article>("select * from Articles;");
            return View(articles);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(db.Articles.Find(id));
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include ="Id,Url,Title,Category,Description,Viewcount,Published,Released,Timestamp")]Article article)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    db.Entry(article).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateConcurrencyException e)
            {
                //競合エラー時はエラー情報を登録
                ModelState.AddModelError(string.Empty, "更新の競合が検出されました。");
            }
            return View(article);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(db.Articles.Find(id));
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            int cnt = db.Database.ExecuteSqlCommand("delete from Articles where id={0}", id);
            return RedirectToAction("Index");
        }

        public ActionResult Navigation(int? id)
        {
            if (id == null)
                id = 1;

            Article article = db.Articles.Find(id);
            return View(article);
        }

    }
}