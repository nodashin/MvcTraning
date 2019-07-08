using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcController.Models;

namespace MvcController.Extensions
{
    public class LoggingAttribute : ActionFilterAttribute
    {
        private MvcControllerContext db = new MvcControllerContext();

        //ActionResultオブジェクトを実行した後に呼び出されるメソッド
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            //引数filterContextがnullの場合は例外を発生
            if(filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }

            //リクエスト情報にアクセスするためのHttpRerquestオブジェクトを取得
            var req = filterContext.HttpContext.Request;
            var log = new AccessLog
            {
                Url = req.Url.AbsolutePath, //絶対URI
                UserAgent = req.UserAgent,  //ユーザーエージェント
                Accessed = DateTime.Now     //現在時刻
            };

            //新規のオブジェクトを追加した上で、データベースに反映
            db.AccessLogs.Add(log);
            db.SaveChanges();
        }
    }
}