using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web.Mvc;
using System.Reflection;
using MvcTest.Extensions;

namespace MvcTest.Tests.Extensions
{
  [TestClass]
  public class ReferrerAttributeTest
  {
    [TestMethod]
    public void IsValidForRequestTest()
    {
      var context = new Mock<ControllerContext>();
      context.SetupGet(c => c.HttpContext.Request.UrlReferrer).
          Returns(new Uri("http://www.wings.msn.to/Test/Previous"));
      context.SetupGet(c => c.HttpContext.Request.Url).
          Returns(new Uri("http://www.web-deli.com/Member/Create"));
      var info = new Mock<MethodInfo>();
      var attr = new ReferrerAttribute(true);
      var result = attr.IsValidForRequest(context.Object, info.Object);
      Assert.IsFalse(result);
    }
  }
}
