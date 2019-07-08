using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MvcTest.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MvcTest.Controllers.Tests
{
    [TestClass()]
    public class BeginControllerTests
    {
        [TestMethod()]
        public void ShowTest()
        {
            var ctrl = new BeginController();
            var result = ctrl.Show() as ViewResult;
            Assert.AreEqual("こんにちは、世界！", result.ViewBag.Message);
            Assert.AreEqual(string.Empty, result.ViewName);
        }

        [TestMethod()]
        public void ListTest()
        {
            //BeginControllerクラスに対応するモックを定義
            var mock = new Mock<BeginController>();

            //ViewResultオブジェクトを返すListメソッドの定義
            mock.Setup(c => c.List()).Returns(new ViewResult() { ViewName = "List" });

            //モックオブジェクト(BeginControllerの身代わり)を取得
            var ctrl = mock.Object;
            //モックのリストメソッドを呼び出し、その値を検証。
            var result = ctrl.List() as ViewResult;
            Assert.AreEqual("List", result.ViewName);
        }
    }
}