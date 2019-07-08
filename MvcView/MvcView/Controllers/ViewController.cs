using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcView.Models;

namespace MvcView.Controllers
{
    public class ViewController : Controller
    {
        MvcViewContext db = new MvcViewContext();

        // GET: View
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Form()
        {
            Article article = db.Articles.Find(1);
            return View(article);
        }

        public ActionResult Select()
        {
            ViewBag.SelectOptions = new SelectListItem[]
            {
                new SelectListItem(){ Value = "jQuery Tips", Text="jQuery Tips"},
                new SelectListItem(){ Value = "jQuery リファレンス", Text="jQuery リファレンス"},
                new SelectListItem(){ Value = "jQuery サンプル集", Text="jQuery サンプル集"},
            };

            ViewBag.ListOptions = new SelectListItem[]
            {
                new SelectListItem(){ Value = "絶品！", Text="絶品！"},
                new SelectListItem(){ Value = "面白かった", Text="面白かった"},
                new SelectListItem(){ Value = "可もなく不可もなく", Text="可もなく不可もなく"},
                new SelectListItem(){ Value = "イマイチ！", Text="イマイチ！"},
            };

            return View();
        }

        public ActionResult SelectEnum()
        {
            return View();
        }

        public ActionResult SelectGroup()
        {
            //選択オプションのリスト
            var articles = db.Articles.Select(a => new { a.Url, a.Title, a.Category });
            //無効オプションのリスト
            var disabled = db.Articles.Where(a => a.Released == false).Select(a => a.Url);
            //選択リストを定義
            ViewBag.Opts = new SelectList(articles, "Url", "Title", "Category", null, disabled);

            return View(db.Articles.Find(1));
        }

        public ActionResult FormNotFor()
        {
            return View();
        }
    }
}