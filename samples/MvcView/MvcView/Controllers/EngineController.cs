using System.Web.Mvc;
using System.Xml.Linq;

namespace MvcView.Controllers
{
  public class EngineController : Controller
  {
    public ActionResult Translate()
    {
      var doc = XDocument.Parse(@"
        <books>
          <book isbn='978-4-7980-3300-6'>
            <title>はじめてのJSP＆サーブレット</title>
            <price>2600</price>
            <publish>秀和システム</publish>
            <published>2012-03-24</published>
          </book>
          <book isbn='978-4-7981-3257-0'>
            <title>独習ASP.NET</title>
            <price>3800</price>
            <publish>翔泳社</publish>
            <published>2013-07-22</published>
          </book>
          <book isbn='978-4-7741-6410-6'>
            <title>Rails 4アプリケーションプログラミング</title>
            <price>3500</price>
            <publish>技術評論社</publish>
            <published>2014-04-11</published>
          </book>
          <book isbn='978-4-7980-3585-7'>
            <title>はじめてのAndroidアプリ開発</title>
            <price>3000</price>
            <publish>秀和システム</publish>
            <published>2012-11-22</published>
          </book>
          <book isbn='978-4-8222-9836-4'>
            <title>.NET開発テクノロジ入門</title>
            <price>3800</price>
            <publish>日経BP</publish>
            <published>2014-06-05</published>
          </book>
        </books>  ");
      ViewBag.Publish = "秀和システム";
      return View(doc);
    }
  }
}