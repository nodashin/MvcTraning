using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using MvcController.Extensions;
using MvcController.Models;

namespace MvcController.Controllers
{
    public class ResultController : Controller
    {
        private MvcControllerContext db = new MvcControllerContext();

        // GET: Result
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Out()
        {
            return Redirect("http://www.wings.msn.to/");
        }

        public ActionResult Out2()
        {
            return RedirectToAction("Index", "Members");
        }

        public ActionResult Out3()
        {
            //return RedirectToAction("Details", "Members", new { id = "1", charset = "utf8" });
            return RedirectToRoute("Default", new { controller = "Members", action = "Details", id = 1, charset = "utf8" });
            //return new HttpUnauthorizedResult();
        }

        public void Empty()
        {
            //戻り値を返さない。
            //return new EmptyResult();
        }

        public string Text()
        {
            //return Content("こんにちは、世界！", "text/plain");
            //return Content("こんにちは、世界！", System.Net.Mime.MediaTypeNames.Text.Plain);
            return "こんにちは、世界！";
        }

        public ActionResult Tsv()
        {
            var members = db.Members.ToList();
            var str = new StringBuilder();
            members.ForEach(m =>
                str.Append(
                    string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\r\n",
                    m.Id,
                    m.Name,
                    m.Email,
                    m.Birth.ToString("d"),
                    m.Married,
                    m.Memo.Replace("\r\n", "")
                    )));

            Response.AddHeader("Content-Disposition", "attachemnt;filename=sample.txt");
            return Content(str.ToString(), "text/tab-separated-values", Encoding.GetEncoding("shift-jis"));
        }

        public ActionResult Rss()
        {
            //Contentテーブルから最終更新日について降順に先頭15件を取得
            var content = db.Articles.OrderByDescending(a => a.Published).Take(15).ToList();

            //取得した結果に基づいてフィードを生成
            var rss = new XDocument(new XDeclaration("1,0", "UTF-8", "yes"),
                                    new XElement("rss",
                                                 new XAttribute("version", "2.0"),
                                                 new XElement("channel",
                                                              new XElement("title", "サーバサイド技術の学び舎"),
                                                              new XElement("link", "http://www.wings.msn.to/"),
                                                              new XElement("description", "サーバ関連の記事情報"),
                                                              new XElement("image",
                                                                           new XElement("url", "http://www.wings.msn.to/image/wings.jpg"),
                                                                           new XElement("link", "http://www.wings.msn.to/"),
                                                                           new XElement("title", "サーバサイドの学び舎")
                                                                          ),
                                                              content.Select(c => new XElement("item",
                                                                                               new XElement("title", c.Title),
                                                                                               new XElement("link", c.Url),
                                                                                               new XElement("description", c.Description),
                                                                                               new XElement("category", c.Category),
                                                                                               new XElement("viewcount", c.Viewcount),
                                                                                               new XElement("pubDate", c.Published.ToUniversalTime().ToString("R"))
                                                                                              ))
                                                              )
                                                )
                                    );

            //XDocumentオブジェクトの内容を文字列変換&クライアントに出力
            return Content(rss.ToString(), "application/rss+xml");
        }

        public ActionResult Download(int id)
        {
            //引数idの値をもとに、画像ファイルの絶対パスを生成
            var pic = Server.MapPath(string.Format("~/App_Data/Photos/PIC{0}.jpg", id));

            //パスが実在する場合のみファイルをダウンロード
            if(System.IO.File.Exists(pic))
            {
                return File(pic, "image/jpeg", "download.jpg");
            }
            return HttpNotFound("File dose not exist.");
        }

        public ActionResult Image(int id)
        {
            var img = db.Images.Find(id);
            return File(img.Data, img.CType, img.Name);
        }

        public ActionResult Pdf()
        {
            var stream = new MemoryStream();
            var doc = new Document();

            //PDF文書の出力先をメモリー(MemoryStreamオブジェクト)に設定
            var writer = PdfWriter.GetInstance(doc, stream);
            //文章を開始
            doc.Open();
            //日本語を扱うためのフォントを生成
            Font fnt = new Font(BaseFont.CreateFont(@"C:\Windows\Fonts\msgothic.ttc, 1", BaseFont.IDENTITY_H, true), 18, Font.BOLD);
            //文字列を追加
            doc.Add(new Paragraph("こんにちは、世界！", fnt));
            //文章を終了
            doc.Close();
            //生成したPDF文書を出力
            return File(stream.ToArray(), "application/pdf", "sample.pdf");
        }

        public ActionResult Custom()
        {
            var doc = XDocument.Parse(@"
                <books>
                    <book isbn='978-4-7890-3300-6'>
                        <title>はじめてのJSP＆サーブレット</title>
                        <price>2600</price>
                        <publish>秀和システム</publish>
                        <published>2012-03-24</published>
                    </book>
                    <book isbn='978-4-7981-3257-0'>
                        <title>独習ASP.NET</title>
                        <price>3800</price>
                        <publish>翔泳社</publish>
                        <published>2013-07-22</published>
                    </book>
                    <book isbn='978-4-7741-6410-6'>
                        <title>Rails 4アプリケーションプログラミング</title>
                        <price>3500</price>
                        <publish>技術評論社</publish>
                        <published>2014-04-11</published>
                    </book>
                    <book isbn='978-4-7890-3585-7'>
                        <title>はじめてのAndroidアプリ開発</title>
                        <price>3000</price>
                        <publish>秀和システム</publish>
                        <published>2012-11-22</published>
                    </book>
                    <book isbn='978-4-8222-9836-4'>
                        <title>.NET開発テクノロジ入門</title>
                        <price>3800</price>
                        <publish>日経BP</publish>
                        <published>2014-06-05</published>
                    </book>
                </books>
            ");

            //TranslatedXmlResultクラスの呼び出し
            return new TranslagedXmlResult(doc);
        }
    }
}