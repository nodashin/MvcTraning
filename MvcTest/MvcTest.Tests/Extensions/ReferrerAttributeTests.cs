using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MvcTest.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MvcTest.Extensions.Tests
{
    [TestClass()]
    public class ReferrerAttributeTests
    {
        [TestMethod()]
        public void IsValidForRequestTest()
        {
            //ControllerContextクラスのモックを準備(リファラーとリクエストURLを設定)
            var context = new Mock<ControllerContext>();
            context.SetupGet(c => c.HttpContext.Request.UrlReferrer).Returns(new Uri("http://www.wings.msn.to/Test/Previous"));
            context.SetupGet(c => c.HttpContext.Request.Url).Returns(new Uri("http://www.web-deli.com/Member/Create"));

            //MethodInfoクラスのモックを準備
            var info = new Mock<MethodInfo>();

            //ReferrerAttributeクラスをインスタンス化&IsValidForRequestメソッドを実行
            var attr = new ReferrerAttribute(true);
            var result = attr.IsValidForRequest(context.Object, info.Object);

            //メソッドの戻り値がfalseであることをチェック
            Assert.IsFalse(result);
        }
    }
}