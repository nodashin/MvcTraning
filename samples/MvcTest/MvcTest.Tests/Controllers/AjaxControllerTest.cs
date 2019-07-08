using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MvcTest.Controllers;
using MvcTest.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcTest.Tests.Controllers
{
  [TestClass]
  public class AjaxControllerTest
  {
    [TestMethod]
    public void GourmetResultTest()
    {
      var request = new Mock<HttpRequestBase>();
      request.Setup(x => x.Headers).Returns(
        new System.Net.WebHeaderCollection {
          {"X-Requested-With", "XMLHttpRequest"}
        }
      );
      var context = new Mock<HttpContextBase>();
      context.Setup(x => x.Request).Returns(request.Object);

      var ctrl = new AjaxController();
      ctrl.ControllerContext = new ControllerContext(context.Object, new RouteData(), ctrl);
      ctrl.Url = new UrlHelper();
      var result = ctrl.GourmetResult("焼き肉");
      Assert.IsInstanceOfType(result, typeof(PartialViewResult));
      var rests = ((PartialViewResult)result).Model as IEnumerable<Restaurant>;
      Assert.AreEqual(rests.Count(), 10);
    }
  }
}
