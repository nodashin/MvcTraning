using MvcController.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using MvcController.Extensions;

namespace MvcController.Controllers
{
    public class BindController : Controller
    {
      private MvcControllerContext db = new MvcControllerContext();

      public ActionResult CreateList() {
        return View();
      }

      [HttpPost]
      public ActionResult CreateList(IList<Member> list)
      {
        try
        {
          foreach (var member in list)
          {
            if (String.IsNullOrEmpty(member.Name)) { break; }
            db.Members.Add(member);
          }
          db.SaveChanges();
          return RedirectToAction("Index");
        }
        catch
        {
          return View();
        }
      }

      // キー／値形式（IDictionary型）の引数にデータをバインドする場合
      //[HttpPost]
      //public ActionResult CreateList(IDictionary<String, Member> list)
      //{
      //  try
      //  {
      //    foreach (var member in list)
      //    {
      //      if (String.IsNullOrEmpty(member.Value.Name)) { break; }
      //      db.Members.Add(member.Value);
      //    }
      //    db.SaveChanges();
      //    return RedirectToAction("Index");
      //  }
      //  catch
      //  {
      //    return View();
      //  }
      //}

      public ActionResult Index()
      {
        return Content("登録しました。");
      }

      public ActionResult Upload()
      {
        return View();
      }

      [HttpPost]
      public ActionResult Upload(HttpPostedFileBase data)
      {
        if (data != null)
        {
          var f = data.FileName;
          var permit = new string[] { ".jpg", ".png", ".gif" };
          if (!permit.Contains(Path.GetExtension(f)))
          {
            ViewBag.Message =
              "jpg、png、gif以外のファイルはアップロードできません。";
            return View();
          }
          data.SaveAs(Path.Combine(
            Server.MapPath("~/App_Data/Photos"), Path.GetFileName(f)));
          ViewBag.Message = f + "をアップロードしました。";
        }
        else
        {
          ViewBag.Message = "ファイルを指定してください。";
        }
        return View();
      }

      ////データベースへのアップロードの場合
      //[HttpPost]
      //public ActionResult Upload(HttpPostedFileBase data)
      //{
      //  if (data != null)
      //  {
      //    var f = data.FileName;
      //    var permit = new string[] { ".jpg", ".png", ".gif" };
      //    if (!permit.Contains(Path.GetExtension(f))) {
      //      ViewBag.Message =
      //        "jpg、png、gif以外のファイルはアップロードできません。";
      //      return View();
      //    }
      //    byte[] bdata = new Byte[data.ContentLength];
      //    data.InputStream.Read(bdata, 0, data.ContentLength);

      //    var img = new Image() {
      //      Name = Path.GetFileName(data.FileName),
      //      Ctype = data.ContentType,
      //      Data = bdata
      //  };
      //  db.Images.Add(img);
      //  db.SaveChanges();
      //  ViewBag.Message = f + "をアップロードしました。";
      //  }
      //  else
      //  {
      //    ViewBag.Message = "ファイルを指定してください。";
      //  }
      //  return View();
      //}

      public ActionResult Provide(string email)
      {
        Response.AppendCookie(new HttpCookie("email")
        {
          Value = "CQW15204@nifty.com",
          Expires = DateTime.Now.AddDays(5)
        });
        return Content(email);
      }

      public ActionResult Custom()
      {
        return View();
      }
      [HttpPost]
      public ActionResult Custom([ModelBinder(typeof(YMDBinder))]DateTime date)
      //public ActionResult Custom(DateTime date)
      {
        return Content(date.ToLongDateString());
      }

    }
}