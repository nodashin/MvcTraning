using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MvcTest.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcTest.Helpers.Tests
{
    [TestClass()]
    public class MyHelperTests
    {
        [TestMethod()]
        public void ImageTest()
        {
            //ViewContextクラスをインスタンス化するための準備
            var context = new Mock<HttpContextBase>(); //HttpContextBaseのモック
            var ctrl = new Mock<ControllerBase>();     //ControllerBaseのモック
            var view = new Mock<IView>();              //IViewのモック

            //ControllerContextオブジェクトを取得
            var ctrlCtx = new ControllerContext(context.Object, new RouteData(), ctrl.Object);
            //ViewContextオブジェクトを取得
            var viewCtx = new ViewContext(ctrlCtx, view.Object, new ViewDataDictionary(), new TempDataDictionary(), new StringWriter());

            var container = new Mock<IViewDataContainer>(); //IViewDataContainerのモック

            //HtmlHelperオブジェクトをインスタンス化
            var html = new HtmlHelper(viewCtx, container.Object);

            //Imageメソッドを実行&戻り値の文字列をチェック
            var result = html.Image("samples.jpg", "テスト");
            Assert.AreEqual("<img src=\"samples.jpg\" alt=\"テスト\" />", result.ToString());

        }
    }
}