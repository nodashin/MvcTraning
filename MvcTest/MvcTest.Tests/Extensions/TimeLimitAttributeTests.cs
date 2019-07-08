using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcTest.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MvcTest.Extensions.Tests
{
    [TestClass()]
    public class TimeLimitAttributeTests
    {
        [TestMethod()]
        public void OnAuthorizationTest()
        {
            //OnAuthorizationメソッドを呼び出す準備
            var context = new AuthorizationContext();

            //フィルター属性のインスタンス化&実行
            var attr = new TimeLimitAttribute("2014/12/01", "2014/12/31");
            attr.OnAuthorization(context);

            //今日が2014/12/01～31以外の場合、ContextResultが返されるはず
            Assert.IsInstanceOfType(context.Result, typeof(ContentResult));
            //また、そのメッセージをチェック
            Assert.AreEqual("このページは2014年12月1日から2014年12月31日までの期間のみ有効です。", ((ContentResult)context.Result).Content);
        }
    }
}