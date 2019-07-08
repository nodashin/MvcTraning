using MvcController.Models;
using System;
using System.Text;
using System.Web.Mvc;
using System.Linq;
using System.Xml.Linq;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using MvcController.Extensions;

namespace MvcController.Controllers
{
  public class ResultController : Controller
  {
    private MvcControllerContext db = new MvcControllerContext();

    public ActionResult Out()
    {
      return Redirect("http://www.wings.msn.to/");
    }

    public ActionResult Out2()
    {
      //return Redirect("~/Members/Index");
      return RedirectToAction("Index", "Members");
    }

    public ActionResult Out3()
    {
      //return RedirectToAction("Details", "Members",
      //  new { id = "1", charset = "utf8" });

      return RedirectToRoute("Default",
        new { controller = "Members", action = "Details",
          id = 1, charset = "utf8" });
    }

    public ActionResult Empty()
    {
      return new EmptyResult();
    }

    //public void Empty()
    //{
    //}

    public ActionResult Text()
    {
      return Content("こんにちは、世界！", "text/plain");

      //return Content("こんにちは、世界！",
      //  System.Net.Mime.MediaTypeNames.Text.Plain);

      //return Content("こんにちは、世界！");
    }

    //public String Text()
    //{
    //  return "こんにちは、世界！";
    //}

    public ActionResult Tsv()
    {
      var members = db.Members.ToList();
      var str = new StringBuilder();
      members.ForEach(m =>
          str.Append(
              String.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\r\n",
                  m.Id,
                  m.Name,
                  m.Email,
                  m.Birth.ToString("d"),
                  m.Married,
                  m.Memo.Replace("\r\n", "")
              )));
      //Response.AddHeader("Content-Disposition", "attachment;filename=sample.txt");
      return Content(str.ToString(),
          "text/tab-separated-values",
          Encoding.GetEncoding("Shift_JIS"));
    }

    public ActionResult Rss()
    {
      var contents = (from c in db.Articles
              orderby c.Published descending
              select c).Take(15).ToList();
      var rss = new XDocument(
              new XDeclaration("1.0", "UTF-8", "yes"),
              new XElement(
                  "rss",
                  new XAttribute("version", "2.0"),
                  new XElement("channel",
                      new XElement("title", "サーバサイド技術の学び舎"),
                      new XElement("link", "http://www.wings.msn.to/"),
                      new XElement("description", "サーバ関連の記事情報"),
                      new XElement("image",
                          new XElement("url", "http://www.wings.msn.to/image/wings.jpg"),
                          new XElement("link", "http://www.wings.msn.to/"),
                          new XElement("title", "サーバサイド技術の学び舎")
                      ),
                      from c in contents
                      select
                      new XElement("item",
                          new XElement("title", c.Title),
                          new XElement("link", c.Url),
                          new XElement("description", c.Description),
                          new XElement("category", c.Category),
                          new XElement("viewcount", c.Viewcount),
                          new XElement("pubDate", c.Published.ToUniversalTime().ToString("R"))
                      )
                  )
              )
          );
      return Content(rss.ToString(), "application/rss+xml");
    }

    public ActionResult Download(int id)
    {
      var pic = Server.MapPath(
          String.Format("~/App_Data/Photos/PIC{0}.jpg", id));
      if (System.IO.File.Exists(pic))
      {
        return File(pic, "image/jpeg", "download.jpg");
      }
      return HttpNotFound("File does not exist.");
    }

    public ActionResult Unsafed(string path)
    {
      return File(path, "application/octet-stream");
    }

    public ActionResult Image(int id)
    {
      var img = (from i in db.Images
                 where i.Id == id
                 select i).FirstOrDefault();
      return File(img.Data, img.Ctype, img.Name);
    }

    public ActionResult Pdf()
    {
      var stream = new MemoryStream();
      var doc = new Document();
      var writer = PdfWriter.GetInstance(doc, stream);
      //Response.ContentType="application/pdf";
      //var writer = PdfWriter.GetInstance(doc, Response.OutputStream);
      doc.Open();
      Font fnt = new Font(BaseFont.CreateFont("c:/windows/fonts/msgothic.ttc, 1", BaseFont.IDENTITY_H, true), 18, Font.BOLD);
      doc.Add(new Paragraph("こんにちは、世界！", fnt));
      doc.Close();
      return File(stream.ToArray(), "application/pdf", "sample.pdf");
      //return new EmptyResult();
    }

    public ActionResult Custom()
    {
      var doc = XDocument.Parse(@"
      <books>
        <book isbn='978-4-7980-3300-6'>
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
        <book isbn='978-4-7980-3585-7'>
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
      return new TranslatedXmlResult(doc);
    }
  }
}