using System;
using System.Text;
using System.Web.Mvc;

namespace MvcTest.Controllers
{
    public class RouteController : Controller
    {
      public ActionResult Test()
      {
        var builder = new StringBuilder();
        foreach (var d in RouteData.Values)
        {
          builder.Append(
            String.Format("{0}：{1}<br />", d.Key, d.Value));
        }
        return Content(builder.ToString());
      }

    }
}