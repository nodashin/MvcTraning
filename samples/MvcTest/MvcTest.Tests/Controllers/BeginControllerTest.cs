using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcTest.Controllers;
using System.Web.Mvc;
using Moq;


namespace MvcTest.Tests.Controllers
{
  [TestClass]
  public class BeginControllerTest
  {
    [TestMethod]
    public void ShowTest()
    {
      var ctrl = new BeginController();
      var result = ctrl.Show() as ViewResult;
      Assert.AreEqual("こんにちは、世界！", result.ViewBag.Message);
      Assert.AreEqual(String.Empty, result.ViewName);
      //Assert.AreEqual("こんにちは！", result.ViewBag.Message);
      //Assert.AreEqual("Show", result.ViewName);

    }

    [TestMethod]
    public void ListTest()
    {
      var mock = new Mock<BeginController>();
      mock.Setup(c => c.List()).Returns(
          new ViewResult() { ViewName = "List" });

      var ctrl = mock.Object;
      var result = ctrl.List() as ViewResult;
      Assert.AreEqual("List", result.ViewName);
    }

  }
}
