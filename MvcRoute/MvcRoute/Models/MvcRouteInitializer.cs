﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcRoute.Models
{
    public class MvcRouteInitializer : DropCreateDatabaseAlways<MvcRouteContext>
    {
        protected override void Seed(MvcRouteContext context)
        {
            var article = new Article
            {
                Url = "http://www.buildinsider.net/web/jquerymobileref",
                Title = "jQuery Mobile逆引きリファレンス",
                Category = CategoryEnum.Reference,
                Description = "jQuery Mobileの基本機能を目的別リファレンスの形式でまとめます。",
                Viewcount = 36452,
                Published = DateTime.Parse("2014-01-09"),
                Released = true
            };
            context.Articles.Add(article);
            context.Comments.Add(new Comment
            {
                Name = "井上鈴子",
                Body = "目的別で探しやすく重宝しています。",
                Updated = DateTime.Parse("2014-06-01"),
                Article = article
            });
            context.Comments.Add(new Comment
            {
                Name = "和田翔太",
                Body = "寸例が載っているのでわかりやすいと思います。",
                Updated = DateTime.Parse("2014-06-11"),
                Article = article
            });

            var article2 = new Article
            {
                Url = "http://codezine.jp/article/corner/518",
                Title = "Bootstrapでレスポンシブでリッチなサイトを構築",
                Category = CategoryEnum.DotNet,
                Description = "ASP.NET MVC5のひな形ページで使用されているBootstrapというフレームワークについて紹介します。",
                Viewcount = 9312,
                Published = DateTime.Parse("2014-05-22"),
                Released = true
            };
            context.Articles.Add(article2);
            context.Comments.Add(new Comment
            {
                Name = "田中三郎",
                Body = "まとめ方が良くてわかりやすかったです。",
                Updated = DateTime.Parse("2014-06-15"),
                Article = article2
            });

            var article3 = new Article
            {
                Url = "http://codezine.jp/article/corner/511",
                Title = "ASP.NET Identity入門",
                Category = CategoryEnum.DotNet,
                Description = "新しい認証、資格管理システムである「ASP.NET Identity」について、どのように使うのか、どんな仕組みで動いているのかを紹介していきます。",
                Viewcount = 8046,
                Published = DateTime.Parse("2014-04-25"),
                Released = true
            };
            context.Articles.Add(article3);
            context.Comments.Add(new Comment
            {
                Name = "和田翔太",
                Body = "自分で調べていて分からなかったところが、分かって良かったです。",
                Updated = DateTime.Parse("2014-07-02"),
                Article = article3
            });


            var article4 = new Article
            {
                Url = "http://codezine.jp/article/corner/513",
                Title = "Amazon Web Servicesによるクラウド超入門",
                Category = CategoryEnum.Cloud,
                Description = "Amazon Web Servicesを使ってクラウドシステム上に簡単なWebシステムを構築していきます。",
                Viewcount = 25687,
                Published = DateTime.Parse("2014-04-25"),
                Released = true
            };
            context.Articles.Add(article4);


            var article5 = new Article
            {
                Url = "http://www.buildinsider.net/web/jqueryuiref",
                Title = "jQuery UI逆引きリファレンス",
                Category = CategoryEnum.Reference,
                Description = "jQuery UIの基本機能を目的別リファレンスの形式でまとめます。",
                Viewcount = 56710,
                Published = DateTime.Parse("2013-07-11"),
                Released = true
            };
            context.Articles.Add(article5);
            context.Comments.Add(new Comment
            {
                Name = "井上鈴子",
                Body = "用例の結果もみられるので、便利です。欲を言うとサンプルコードをダウンロードできるようにしてほしい。",
                Updated = DateTime.Parse("2014-07-01"),
                Article = article5
            });

            var article6 = new Article
            {
                Url = "http://www.wings.msn.to/mvc5",
                Title = "ASP.NET MVC 入門",
                Category = CategoryEnum.DotNet,
                Description = "ASP.NET MVCをこれから始める人のために、詳しく丁寧に段階を追って解説します。",
                Viewcount = 0,
                Published = DateTime.Parse("2015-01-20"),
                Released = false
            };
            context.Articles.Add(article6);

            var article7 = new Article
            {
                Url = "http://www.wings.msn.to/azure",
                Title = "Azure新機能TIPS",
                Category = CategoryEnum.Cloud,
                Description = "Microsoft Azureの新機能についてTIPS形式で、使い方などを解説します。",
                Viewcount = 13469,
                Published = DateTime.Parse("2014-04-25"),
                Released = true
            };
            context.Articles.Add(article7);
        }
    }
}