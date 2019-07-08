using MvcView.Models;
using System.Linq;
using System.Web.Mvc;

namespace MvcView.Controllers
{
    public class ViewController : Controller
    {
      private MvcViewContext db = new MvcViewContext();

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
          ViewBag.SelectOptions = new SelectListItem[] {
            new SelectListItem() { Value="jQuery Tips", Text="jQuery Tips" },
            new SelectListItem() { Value="jQueryリファレンス", Text="jQueryリファレンス" },
            new SelectListItem() { Value="jQueryサンプル集", Text="jQueryサンプル集" }
          };
          ViewBag.ListOptions = new SelectListItem[] {
            new SelectListItem() { Value="絶品！", Text="絶品！" },
            new SelectListItem() { Value="面白かった", Text="面白かった" },
            new SelectListItem() { Value="可もなく不可もなく", Text="可もなく不可もなく" },
            new SelectListItem() { Value="イマイチ！", Text="イマイチ！" }
          };
          return View();
        }

        public ActionResult SelectEnum()
        {
            Article article = db.Articles.Find(1);
            return View(article);
        }

      public ActionResult SelectGroup()
      {
        var articles = from a in db.Articles
                       select new { Url = a.Url, Title = a.Title,
                         Category = a.Category };
        var disabled = from a in db.Articles
                       where a.Released == false
                       select a.Url;

        ViewBag.Opts = new SelectList(
          articles, "Url", "Title", "Category", null, disabled);
        return View(db.Articles.Find(1));
      }

        public ActionResult FormNotFor()
        {
            return View();
        }
    }
}