using MvcTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace MvcTest.Controllers
{
  public class AjaxController : Controller
  {
    public ActionResult GourmetSearch()
    {
      return View();
    }

    public ActionResult GourmetResult(string keyword)
    {
      System.Threading.Thread.Sleep(3000);
      if (Request.IsAjaxRequest())
      {
        var keyid = "b5e1f8xxxxxxxxxxxxxxxxx21005b2";
        var prefid = "PREF13";
        var doc = XElement.Load(
            String.Format("http://api.gnavi.co.jp/ver1/RestSearchAPI/?keyid={0}&name={1}&pref={2}&offset_page={3}",
                keyid, Url.Encode(keyword), prefid, 1));
        ViewBag.Count = Int32.Parse(doc.Element("total_hit_count").Value);
        return PartialView("_GourmetResult", from r in doc.Elements("rest")
          //return Json(from r in doc.Elements("rest")

          select new Restaurant()
          {
            Id = r.Element("id").Value,
            Name = r.Element("name").Value,
            Url = r.Element("url").Value,
            Image = r.Element("image_url").Element("qrcode").Value,
            Pr = r.Element("pr").Element("pr_long").Value
          }
        );
      }
      return Content("Ajax通信以外のアクセスはできません。");
    }
  }
}