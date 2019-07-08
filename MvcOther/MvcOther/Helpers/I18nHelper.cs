using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOther.Helpers
{
    public static class I18nHelper
    {
        //グローバルリソースを取得するビューヘルパー
        public static string GlobalResource(this HtmlHelper helper, string type, string key, params object[] args)
        {
            var context = helper.ViewContext.HttpContext;
            return string.Format((string)context.GetGlobalResourceObject(type, key), args);
        }

        //ローカルリソースを取得するビューヘルパー
        public static string LocalResource(this HtmlHelper helper, string key, params object[] args)
        {
            var context = helper.ViewContext.HttpContext;
            var view = helper.ViewContext.View as RazorView;
            return string.Format((string)context.GetLocalResourceObject(view.ViewPath, key), args);
        }
    }
}