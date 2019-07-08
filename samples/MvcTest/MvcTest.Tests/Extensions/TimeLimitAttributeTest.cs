using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using MvcTest.Extensions;

namespace MvcTest.Tests.Extensions
{
  [TestClass]
  public class TimeLimitAttributeTest
  {
    [TestMethod]
    public void OnAuthorizationTest()
    {
      var context = new AuthorizationContext();
      var attr = new TimeLimitAttribute("2014/12/01", "2014/12/31");
      attr.OnAuthorization(context);

      Assert.IsInstanceOfType(context.Result, typeof(ContentResult));
      Assert.AreEqual(
          "このページは2014年12月1日から2014年12月31日までの期間のみ有効です。",
          ((ContentResult)context.Result).Content);
    }
  }
}
