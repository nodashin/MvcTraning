﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcModel.Models;

namespace MvcModel.Controllers
{
    public class OtherController : Controller
    {
        MvcModelContext db = new MvcModelContext();

        public OtherController()
        {
            db.Database.Log = sql =>
            {
                Debug.Write(sql);
            };
        }

        // GET: Other
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Insert()
        {
            db.Comments.Add(new Comment
            {
                Name = "田中知子",
                Body = "すごく丁寧に説明してあって、良かったです。",
                Updated = DateTime.Parse("2015-01-10"),
                //関連するエンティティも入れ子で設定
                Article = new Article
                {
                    Title = "Visual Studioの使い方",
                    Category = CategoryEnum.DotNet,
                    Description = "初めて使う人でもわかるように、....",
                    Viewcount = 1000,
                    Url = "http://www.wings.msn.to/vs",
                    Published = DateTime.Parse("2015-01-01"),
                    Released = true
                }
            });
            db.SaveChanges();

            return Content("追加しました。");
        }

        public ActionResult Insert2()
        {
            var article = db.Articles.Find(2);
            db.Comments.Add(new Comment
            {
                Name = "林健太",
                Body = "簡単にきれいなレイアウトができるので、面白かった。",
                Updated = DateTime.Parse("2014-06-20"),
                //Article = article,
                ArticleId = 2,
            });
            db.SaveChanges();

            return Content("コメントを追加しました。");
        }

        public ActionResult Update()
        {
            //Id=3のArticleオブジェクトに関連付けを更新
            var article = db.Articles.Find(3);
            var comment = db.Comments.Find(2);
            comment.Article = article;
            db.SaveChanges();

            return Content("更新しました。");
        }

        public ActionResult Delete()
        {
            var a = db.Articles.First();
            var comms = a.Comments;
            db.Articles.Remove(a);
            db.SaveChanges();

            return Content("削除しました。");
        }

        public ActionResult Transaction()
        {
            db.Articles.Add(
                new Article()
                {
                    Url = "http://www.wings.msn.to/asp",
                    Title = "はじめてのASP.NET",
                    Category = CategoryEnum.DotNet,
                    Description = "ASP.NETに初めて触る人のための入門記事です。",
                    Viewcount = 100,
                    Published = DateTime.Parse("2014-09-25"),
                    Released = true
                });
            db.Articles.Add(
                new Article()
                {
                    Url = "http://www.wings.msn.to/phpref",
                    Title = "厳選PHPリファレンス",
                    Category = CategoryEnum.Reference,
                    Description = "よく使うものを選んだPHPのリファレンスです。",
                    Viewcount = 100,
                    Published = DateTime.Parse("2014-10-01"),
                    Released = true
                });

            db.SaveChanges();
            return Content("追加しました。");
        }

        public ActionResult Transaction2()
        {
            using (var tx = db.Database.BeginTransaction())
            {
                try
                {
                    db.Articles.Add(
                        new Article()
                        {
                            Url = "http://www.wings.msn.to/asp",
                            Title = "はじめてのASP.NET",
                            Category = CategoryEnum.DotNet,
                            Description = "ASP.NETに初めて触る人のための入門記事です。",
                            Viewcount = 100,
                            Published = DateTime.Parse("2014-09-25"),
                            Released = true
                        });
                    db.SaveChanges();

                    db.Database.ExecuteSqlCommand("Insert into Articles" +
                        "                          (" +
                        "                            Url, " +
                        "                            Title, " +
                        "                            Category, " +
                        "                            Description, " +
                        "                            Viewcount, " +
                        "                            Published, " +
                        "                            Released" +
                        "                          )  Values " +
                        "                          (" +
                        "                            {0}, " +
                        "                            {1}, " +
                        "                            {2}, " +
                        "                            {3}, " +
                        "                            {4}, " +
                        "                            {5}, " +
                        "                            {6}" +
                        "                          )",
                                                    "http://www.wings.msn.to/phpref", 
                                                    "厳選PHPリファレンス", 
                                                    0,
                                                    "よく使うものを選んだPHPのリファレンスです。",
                                                    1000,
                                                    "2014-10-01",
                                                    true);
                    tx.Commit();
                    return Content("成功しました。");
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    return Content(ex.ToString());
                }
            }
        }
    }
}