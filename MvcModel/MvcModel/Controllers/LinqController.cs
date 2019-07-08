using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcModel.Models;

namespace MvcModel.Controllers
{
    public class LinqController : Controller
    {
        private MvcModelContext db = new MvcModelContext();

        public LinqController()
        {
            db.Database.Log = sql =>
            {
                Debug.Write(sql);
            };
        }

        // GET: Linq
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search(string keyword, bool? released)
        {
            //デフォルトでは全てのデータを取得
            var articles = from a in db.Articles
                           select a;

            //[キーワード]欄が空でない場合、その値で部分一致検索
            if (!string.IsNullOrEmpty(keyword))
            {
                articles = articles.Where(a => a.Title.Contains(keyword));
            }

            if (released.HasValue && released.Value)
            {
                articles = articles.Where(a => a.Released);
            }

            return View(articles);
        }

        public ActionResult OrderBy()
        {
            var articles = from a in db.Articles
                           orderby a.Published descending, a.Title
                           select a;

            return View(articles);
        }

        public ActionResult OrderBy2()
        {
            var articles = db.Articles
                           .OrderByDescending(a => a.Published)
                           .ThenBy(a => a.Title);

            return View(articles);
        }

        public ActionResult Sort(string sort)
        {
            //ソート列／順序を判別するキー文字列を生成
            ViewBag.Title = string.IsNullOrEmpty(sort) ? "dTitle" : "";
            ViewBag.Category = (sort == "Category" ? "dCategory" : "Category");
            ViewBag.Published = (sort == "Published" ? "dPublished" : "Published");
            ViewBag.Viewcount = (sort == "Viewcount" ? "dViewcount" : "Viewcount");

            //デフォルトではソート指定なし
            var articles = from a in db.Articles select a;

            switch (sort)
            {
                case "Category":
                    articles = articles.OrderBy(a => a.Category);
                    break;
                case "Published":
                    articles = articles.OrderBy(a => a.Published);
                    break;
                case "Viewcount":
                    articles = articles.OrderBy(a => a.Viewcount);
                    break;
                case "dTitle":
                    articles = articles.OrderByDescending(a => a.Title);
                    break;
                case "dCategory":
                    articles = articles.OrderByDescending(a => a.Category);
                    break;
                case "dPublished":
                    articles = articles.OrderByDescending(a => a.Published);
                    break;
                case "dViewcount":
                    articles = articles.OrderByDescending(a => a.Viewcount);
                    break;
                default:
                    articles = articles.OrderBy(a => a.Title);
                    break;
            }

            return View(articles);
        }

        public ActionResult Select()
        {
            //var articles = from a in db.Articles
            //               orderby a.Published descending
            //               select new ArticleView
            //               {
            //                   Title = a.Title.Substring(0, 10),
            //                   ViewCount = (int)Math.Ceiling(a.Viewcount / 1000.0),
            //                   Released = a.Released ? "公開中" : "公開予定"
            //               };

            var articles = db.Articles
                           .OrderByDescending(a => a.Published)
                           .Select(a => new ArticleView
                           {
                               Title = a.Title.Substring(0, 10),
                               ViewCount = (int)Math.Ceiling(a.Viewcount / 1000.0),
                               Released = a.Released ? "公開中" : "公開予定"
                           });

            return View(articles);
        }

        public ActionResult SelectMany()
        {
            //Referenceカテゴリーに属する記事のコメント
            var comments = db.Articles
                            .Where(a => a.Category == CategoryEnum.Reference)
                            .Select(a => a.Comments);

            return View(comments);
        }

        public ActionResult SelectMany2()
        {
            var comments = db.Articles
                            .Where(a => a.Category == CategoryEnum.Reference)
                            .SelectMany(a => a.Comments);

            return View(comments);
        }

        public ActionResult SelectMany3()
        {
            var comments = from a in db.Articles
                           where a.Category == CategoryEnum.Reference
                           from c in a.Comments
                           select c;

            return View(comments);
        }

        public ActionResult SelectMany4()
        {
            var comments = db.Articles
                            .Where(a => a.Category == CategoryEnum.Reference)
                            .SelectMany(a => a.Comments
                                            .Select(c => new ArticleCommentView
                                            {
                                                Title = a.Title,
                                                Body = c.Body
                                            }));
            return View(comments);
        }

        public ActionResult Distinct()
        {
            var comments = db.Comments.OrderBy(c => c.Name).Select(c => c.Name).Distinct();

            return View(comments);
        }

        public ActionResult Skip()
        {
            var articles = db.Articles.OrderByDescending(a => a.Published).Select(a => a).Skip(4).Take(3);

            return View(articles);
        }

        public ActionResult Paging(int? id)
        {
            var pageSize = 3;
            var pageNum = (id ?? 1) - 1;
            var articles = db.Articles
                            .OrderByDescending(a => a.Published)
                            .Skip(pageNum * pageSize)
                            .Take(pageSize);
            return View(articles);
        }

        public ActionResult First()
        {
            var article = db.Articles
                            .OrderByDescending(a => a.Published)
                            .First();

            return View(article);
        }

        public ActionResult FirstOrDefault()
        {
            var article = db.Articles
                            .Where(a => a.Url == "hoge")
                            .FirstOrDefault();

            if (article == null)
            {
                return Content("該当する記事情報は存在しません。");
            }

            return View();
        }

        public ActionResult Group()
        {
            var articles = db.Articles.GroupBy(a => a.Category);

            return View(articles);
        }

        public ActionResult Group2()
        {
            var articles = db.Articles.GroupBy(a => a.Category, a => new ArticleLinkView { Url = a.Url, Title = a.Title });

            return View(articles);
        }

        public ActionResult MultiGroup()
        {
            var articles = db.Articles
                            .GroupBy(a => new ArticleGroup
                            {
                                Category = a.Category,
                                Published = a.Published
                            });

            return View(articles);
        }

        public ActionResult Having()
        {
            var articles = db.Articles.GroupBy(a => a.Category)
                                      .Where(group => group.Average(a => a.Viewcount) > 10000)
                                      .Select(group => new ArticleHaving
                                      {
                                          Category = group.Key,
                                          ViewAverage = group.Average(a => a.Viewcount)
                                      });

            return View(articles);
        }

        public ActionResult Having2()
        {
            var articles = db.Articles
                            .GroupBy(a => a.Category)
                            .OrderBy(g => g.Key.ToString());

            return View(articles);
        }

        public ActionResult Join()
        {
            var articles = db.Articles
                                .Join(db.Comments, a => a, c => c.Article,
                                (a, c) => new ArticleCommentView
                                {
                                    Title = a.Title,
                                    Body = c.Body
                                });
            return View(articles);
        }
    }
}