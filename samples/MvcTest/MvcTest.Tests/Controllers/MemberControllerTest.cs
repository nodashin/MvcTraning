using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcTest.Controllers;
using MvcTest.Tests.Models;
using System.Web.Mvc;
using System.Collections.Generic;
using MvcTest.Models;
using System.Linq;

namespace MvcTest.Tests.Controllers
{
  [TestClass]
  public class MemberControllerTest
  {
    private MembersController _ctrl;

    [TestInitialize]
    public void MyTestInitialize()
    {
      this._ctrl = new MembersController(new MemberTestRepository());
    }

    [TestMethod]
    public void IndexTest()
    {
      var result = this._ctrl.Index() as ViewResult;
      Assert.AreEqual(5, ((IEnumerable<Member>)result.Model).Count());
    }

    [TestMethod]
    public void CreateTest()
    {
      var result = this._ctrl.Create(
        new Member()
        {
          Id = 10,
          Name = "山田田吾作",
          Email = "tagosaku@examples.com",
          Birth = new DateTime(2005, 12, 4),
          Married = false,
          Memo = "メモテスト"
        }
      );
      Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
    }
  }
}