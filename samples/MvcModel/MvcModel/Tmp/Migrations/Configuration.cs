namespace MvcModel.Migrations
{
  using MvcModel.Models;
  using System;
  using System.Collections.Generic;
  using System.Data.Entity;
  using System.Data.Entity.Migrations;
  using System.Linq;


    internal sealed class Configuration : DbMigrationsConfiguration<MvcModel.Models.MvcModelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "MvcModel.Models.MvcModelContext";
        }

        protected override void Seed(MvcModel.Models.MvcModelContext context)
        {
          var article1 = new Article
          {            
            Url = "http://www.buildinsider.net/web/jquerymobileref",
            Title = "jQuery Mobile逆引きリファレンス",
            Category = CategoryEnum.Reference,
            Description = "jQuery Mobileの基本機能を目的別リファレンスの形式でまとめます。",
            Viewcount = 36452,
            Published = DateTime.Parse("2014-01-09"),
            Released = true
          };
          var article2 = new Article
          {
            Url = "http://codezine.jp/article/corner/518",
            Title = "Bootstrapでレスポンシブでリッチなサイトを構築",
            Category = CategoryEnum.Cloud,
            Description = "ASP.NET MVC5のひな形ページで使用されているBootstrapというフレームワークについて紹介します。",
            Viewcount = 9312,
            Published = DateTime.Parse("2014-05-22"),
            Released = true
          };
          var article3 = new Article
          {
            Url = "http://codezine.jp/article/corner/511",
            Title = "ASP.NET Identity入門",
            Category = CategoryEnum.DotNet,
            Description = "新しい認証、資格管理システムである「ASP.NET Identity」について、どのように使うのか、どんな仕組みで動いているのかを紹介していきます。",
            Viewcount = 8046,
            Published = DateTime.Parse("2014-04-18"),
            Released = true
          };
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
          context.Articles.AddOrUpdate(a => a.Url, article1, article2, article3, article4, article5);

          var comment = new Comment
          {
            Name = "井上鈴子",
            Body = "目的別で探しやすく重宝しています。",
            Updated = DateTime.Parse("2014-06-01"),
            Article = article1
          };
          var comment2 = new Comment
          {
            Name = "和田翔太",
            Body = "寸例が載っているのでわかりやすいと思います。",
            Updated = DateTime.Parse("2014-06-11"),
            Article = article1
          };
          var comment3 = new Comment
          {
            Name = "田中三郎",
            Body = "まとめ方が良くてわかりやすかったです。",
            Updated = DateTime.Parse("2014-06-15"),
            Article = article2
          };
          context.Comments.AddOrUpdate( c => c.Body, comment, comment2, comment3);

          var author1 = new Author
          {
            Name = "山田太郎",
            Email = "taro@wings.msn.to",
            Birth = DateTime.Parse("1970-12-10"),
            Articles = new List<Article> { article1, article2, article3, article5 }
          };
          var author2 = new Author
          {
            Name = "鈴木久美",
            Email = "kumi@wings.msn.to",
            Birth = DateTime.Parse("1985-11-12"),
            Articles = new List<Article> { article1, article4 }
          };
          var author3 = new Author
          {
            Name = "佐藤敏夫",
            Email = "toshi@wings.msn.to",
            Birth = DateTime.Parse("1975-05-26"),
            Articles = new List<Article> { article1, article2 }
          };
          context.Authors.AddOrUpdate(au => au.Email, author1, author2, author3);

          var member1 = new Member
          {
            Name = "山田リオ",
            Email = "rio@wings.msn.to",
            Birth = DateTime.Parse("1980-06-25"),
            Married = false,
            Memo = "ピアノが大好きです。"
          };
          var member2 = new Member
          {
            Name = "日尾直弘",
            Email = "naohiro@wings.msn.to",
            Birth = DateTime.Parse("1975-07-19"),
            Married = false,
            Memo = "子どもにもやさしいお医者さんです。"
          };
          var member3 = new Member
          {
            Name = "掛谷奈美",
            Email = "nami@wings.msn.to",
            Birth = DateTime.Parse("1985-08-05"),
            Married = false,
            Memo = "フラワーアレンジメントを勉強中です。"
          };
          var member4 = new Member
          {
            Name = "木村次郎",
            Email = "jiro@wings.msn.to",
            Birth = DateTime.Parse("1970-12-15"),
            Married = true,
            Memo = "山登りが趣味です。休日は、よく山へ出かけます。"
          };
          var member5 = new Member
          {
            Name = "鈴木恵子",
            Email = "keiko@wings.msn.to",
            Birth = DateTime.Parse("1984-11-23"),
            Married = true,
            Memo = "子どもと一緒にアニメを見るのが大好きです。"
        };
          context.Members.AddOrUpdate(m => m.Email, member1, member2, member3, member4, member5);

          context.SaveChanges();
        }
    }
}
