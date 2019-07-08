using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcController.Models;

namespace MvcController.Extensions
{
    public class LoggingErrorAttribute : FilterAttribute, IExceptionFilter
    {
        private MvcControllerContext db = new MvcControllerContext();

        //アクションメソッドで例外が発生した時に呼び出されるメソッド
        public void OnException(ExceptionContext filterContext)
        {
            //引数filterContextがnullの場合には例外を発生
            if(filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }

            //ルートパラメータを取得
            var route = filterContext.RouteData;
            //アクションメソッドで発生した例外情報を取得
            var exp = filterContext.Exception;

            var err = new ErrorLog
            {
                Controller = route.Values["controller"].ToString(), //コントローラー名
                Action = route.Values["action"].ToString(),         //アクション名
                Message = exp.Message,                              //例外メッセージ
                Stacktrace = exp.StackTrace,                        //スタックトレース
                Updated = DateTime.Now                              //例外発生日時
            };
            //新規のオブジェクトを追加した上で、データベースに反映
            db.ErrorLogs.Add(err);
            db.SaveChanges();
            filterContext.ExceptionHandled = false;
            filterContext.Result = new ContentResult() { Content = "例外は処理されました。" };
        }
    }
}