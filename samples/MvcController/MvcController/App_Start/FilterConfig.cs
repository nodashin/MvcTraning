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

      //filters.Add(new HandleErrorAttribute() { View = "ErrorSpare" });
      
      //filters.Add(new HandleErrorAttribute()
      //{
      //  Order = 2,
      //  ExceptionType = typeof(ArgumentException),
      //  View = "ErrorSpare"
      //});
    }
  }
}
