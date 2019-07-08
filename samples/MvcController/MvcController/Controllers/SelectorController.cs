using MvcController.Extensions;
using System.Web.Mvc;

namespace MvcController.Controllers
{
    public class SelectorController : Controller
    {
      [Referrer(true)]
      public ActionResult Index()
      {
        return Content("アクセスに成功しています。");
      }

      [MyAction]
      public ActionResult HogeAction()
      {
        return Content("正しく呼び出されました。");
      }
    }
}