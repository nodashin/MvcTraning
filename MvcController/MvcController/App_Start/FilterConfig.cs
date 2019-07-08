using System;
using System.Web;
using System.Web.Mvc;

namespace MvcController
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new HandleErrorAttribute()
            //{
            //    Order = 2,                                 //実行順序
            //    ExceptionType = typeof(ArgumentException), //例外の種類
            //    View = "ErrorSpare"                        //ビュー名
            //});
        }
    }
}
