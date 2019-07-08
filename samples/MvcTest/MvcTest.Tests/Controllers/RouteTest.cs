using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web;
using System.Web.Routing;

namespace MvcTest.Tests.Controllers
{
  [TestClass]
  public class RouteTest
  {
    [TestMethod]
    public void MyRouteTest()
    {
      RouteCollection routes = new RouteCollection();
      RouteConfig.RegisterRoutes(routes);

      var context = new Mock<HttpContextBase>();
      context.Setup(c => c.Request.AppRelativeCurrentExecutionFilePath).Returns("~/Blog/04/12/2013");
      context.Setup(c => c.Request.HttpMethod).Returns("GET");
      RouteData data = routes.GetRouteData(context.Object);

      Assert.IsNotNull(data);
      Assert.AreEqual("Route", data.Values["controller"]);
      Assert.AreEqual("Test", data.Values["action"]);
      Assert.AreEqual("2013", data.Values["year"]);
    }
  }
}
