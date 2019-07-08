using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcController.Extensions;
using MvcController.Models;

namespace MvcController.Controllers
{
    public class BindController : Controller
    {
        private MvcControllerContext db = new MvcControllerContext();

        // GET: Bind
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateList()
        {
            return View();
        }

        //[登録]ボタンクリック時に呼び出され、登録処理を行うアクション
        [HttpPost]
        public ActionResult CreateList(IDictionary<string, Member> list)
        {
            try
            {
                //リストから順にMemberオブジェクトを取り出す
                foreach (var member in list)
                {
                    //Nameプロパティが空のところで処理を中断
                    if(string.IsNullOrEmpty(member.Value.Name)) { break; }
                    //Memberオブジェクトを追加&データソースに反映
                    db.Members.Add(member.Value);
                }
                db.SaveChanges();

                return RedirectToAction("CreateList");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase data)
        {
            if(data != null)
            {
                var f = data.FileName; //ファイル名

                //拡張子をチェック
                var permit = new string[] { ".jpg", ".png", ".gif" };
                if(!permit.Contains(Path.GetExtension(f)))
                {
                    ViewBag.Message = "jpg、png、gif以外のファイルはアップロードできません。";
                    return View();
                }

                //アップロードファイルを保存
                //data.SaveAs(Path.Combine(Server.MapPath("~/App_Data/Photos"), Path.GetFileName(f)));
                //ViewBag.Message = f + "をアップロードしました。";
                byte[] bdata = new byte[data.ContentLength];
                data.InputStream.Read(bdata, 0, data.ContentLength);
                //Imageオブジェクトを生成
                var image = new Image()
                {
                    Name = Path.GetFileName(data.FileName),
                    CType = data.ContentType,
                    Data = bdata
                };
                db.Images.Add(image);
                db.SaveChanges();
            }
            else
            {
                ViewBag.Message = "ファイルを指定してください。";
            }
            return View();
        }

        public ActionResult Provide(string email)
        {
            //クッキーemailを発行
            Response.AppendCookie(new HttpCookie("email")
            {
                Value = "CQW15204@nifty.com",
                Expires = DateTime.Now.AddDays(5)
            });

            //引数email経由で取得したクッキーを取得。
            return Content(email);
        }

        public ActionResult Custom()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Custom([ModelBinder(typeof(YMDBinder))] DateTime date)
        {
            //日付値をテキストとして取得
            return Content(date.ToLongDateString());
        }
    }
}