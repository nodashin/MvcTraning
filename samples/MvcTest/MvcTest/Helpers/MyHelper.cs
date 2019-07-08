using System;
using System.Web;
using System.Web.Mvc;

namespace MvcTest.Helpers
{
  public static class MyHelper
  {
    public static IHtmlString Image(this HtmlHelper helper, String src, String alt)
    {
      return MvcHtmlString.Create(
        String.Format("<img src=\"{0}\" alt=\"{1}\" />",
        HttpUtility.HtmlAttributeEncode(
          UrlHelper.GenerateContentUrl(src, helper.ViewContext.HttpContext)),
        HttpUtility.HtmlAttributeEncode(alt)));
    }
  }
}