using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace MvcController.Extensions
{
    public class MyActionAttribute : ActionNameSelectorAttribute
    {
        //アクション名がリクエストの内容と一致するかを判定
        public override bool IsValidName(ControllerContext controllerContext, string actionName, MethodInfo methodInfo)
        {
            //現在のメソッド名(アクション名ではなく)を取得
            var name = methodInfo.Name;

            //メソッド名の末尾が「Action」で終わっており、かつ、メソッド名の末尾から「Action」を取り除いた名前が指定されたアクション名と等しいか
            return name.EndsWith("Action") && string.Equals(actionName, name.Substring(0, name.Length - 6), StringComparison.OrdinalIgnoreCase);
        }
    }
}