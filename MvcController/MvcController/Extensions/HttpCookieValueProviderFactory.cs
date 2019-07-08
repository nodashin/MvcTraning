using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcController.Extensions
{
    public class HttpCookieValueProviderFactory : ValueProviderFactory
    {
        public override IValueProvider GetValueProvider(ControllerContext controllerContext)
        {
            var list = new NameValueCollection();

            //クッキー情報をNameValueCollectionに詰め替え
            var cookies = controllerContext.HttpContext.Request.Cookies;
            foreach (var key in cookies.AllKeys)
            {
                list.Add(key, cookies[key].Value);
            }

            //NameValueCollectionから値プロパイダーを生成
            return new NameValueCollectionValueProvider(list, CultureInfo.CurrentCulture);
        }
    }
}