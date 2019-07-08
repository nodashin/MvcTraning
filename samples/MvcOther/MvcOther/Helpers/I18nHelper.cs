using System;
using System.Web.Mvc;

namespace MvcOther.Helpers
{
  public static class I18nHelper
  {
    public static string GlobalResource(
      this HtmlHelper helper, string type, string key, params object[] args)
    {
      var context = helper.ViewContext.HttpContext;
      return String.Format(
        (string)context.GetGlobalResourceObject(type, key), args);
    }

    public static string LocalResource(
      this HtmlHelper helper, string key, params object[] args)
    {
      var context = helper.ViewContext.HttpContext;
      var view = helper.ViewContext.View as RazorView;
      return String.Format(
        (string)context.GetLocalResourceObject(view.ViewPath, key), args);
    }
  }
}