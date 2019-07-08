using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace MvcController.Extensions
{
    public class ReferreAttribute : ActionMethodSelectorAttribute
    {
        //Referreヘッダーがnullであることを許可するか
        public bool CanNull { get; private set; }

        //コンストラクター(CanNullプロパティを初期化)
        public ReferreAttribute(bool canNull)
        {
            CanNull = canNull;
        }

        //リクエストに対してアクションの呼び出しを行うかどうかを判定
        public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
        {
            //HttpRequestオブジェクトを取得
            var req = controllerContext.HttpContext.Request;

            //Referreヘッダーを取得
            var referre = req.UrlReferrer;

            //Referreヘッダーがnullの場合、nullを許可していればtrue
            if(referre == null) { return CanNull; }

            //ReferreヘッダーとリクエストURLのホスト名を比較(等しい場合のみtrue)
            var refHost = referre.Host;
            var currentHost = req.Url.Host;
            return refHost.Equals(currentHost, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}