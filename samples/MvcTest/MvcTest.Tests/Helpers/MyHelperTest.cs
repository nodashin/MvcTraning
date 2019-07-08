using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcTest.Helpers;
using Moq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.IO;

namespace MvcTest.Tests.Helpers
{
  [TestClass]
  public class MyHelperTest
  {
    [TestMethod]
    public void ImageTest()
    {
      var context = new Mock<HttpContextBase>();
      var ctrl = new Mock<ControllerBase>();
      var view = new Mock<IView>();
      var ctrlCtx = new ControllerContext(
        context.Object, new RouteData(), ctrl.Object);
      var viewCtx = new ViewContext(ctrlCtx, view.Object,
        new ViewDataDictionary(), new TempDataDictionary(), new StringWriter());

      // var viewCtx = new ViewContext();
      var container = new Mock<IViewDataContainer>();
      var html = new HtmlHelper(viewCtx, container.Object);
      var result = html.Image("samples.jpg", "テスト");
      Assert.AreEqual("<img src=\"samples.jpg\" alt=\"テスト\" />",
        result.ToString());
    }
  }
}
