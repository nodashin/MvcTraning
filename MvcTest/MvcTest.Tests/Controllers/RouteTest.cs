using System;
using System.Web;
using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MvcTest.Tests.Controllers
{
    [TestClass]
    public class RouteTest
    {
        [TestMethod]
        public void MyRouteTest()
        {
            //RouteConfig.csで定義されたルート情報を設定
            RouteCollection routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            //HttpContexBaseクラスのモックを定義(リクエストパスとJTTPメソッドをセット)
            var context = new Mock<HttpContextBase>();
            context.Setup(c => c.Request.AppRelativeCurrentExecutionFilePath).Returns("~/Blog/04/12/2013");
            context.Setup(c => c.Request.HttpMethod).Returns("GET");

            //ルートパラメータを取得
            RouteData data = routes.GetRouteData(context.Object);

            //ルートパラメータをチェック
            Assert.IsNotNull(data);
            Assert.AreEqual("Route", data.Values["controller"]); //コントローラー名
            Assert.AreEqual("Test", data.Values["action"]);      //アクション名
            Assert.AreEqual("2013", data.Values["year"]);        //{year}パラメーター
        }
    }
}
