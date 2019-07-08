using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcTest.Controllers;
using MvcTest.Models;
using MvcTest.Tests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MvcTest.Controllers.Tests
{
    [TestClass()]
    public class MembersControllerTests
    {
        private MembersController _ctrl;

        //テストの初期化処理
        [TestInitialize]
        public void MyTestInitialize()
        {
            //テスト用のリポジトリをコントローラーに設定
            this._ctrl = new MembersController(new MemberTestRepository());
        }


        [TestMethod()]
        public void IndexTest()
        {
            //アクションを実行
            var result = this._ctrl.Index() as ViewResult;
            //取得したオブジェクトの件数をチェック
            Assert.AreEqual(5, ((IEnumerable<Member>)result.Model).Count());
        }

        [TestMethod()]
        public void CreateTest()
        {
            //アクションを実行
            var result = this._ctrl.Create(
                new Member()
                {
                    Id = 10,
                    Name = "山田田吾作",
                    Email = "tagosaku@exsample.com",
                    Birth = new DateTime(2005, 12, 4),
                    Married = false,
                    Memo = "メモテスト"
                });

            //戻り値の型をチェック
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
        }

    }
}