using System.Web.Mvc;

namespace MvcRoute.Others
{
  public class RouteController : Controller
  {
    public ActionResult Test()
    {
      return Content("Others 名前空間です。");
    }
  }
}