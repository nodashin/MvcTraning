using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcTest.Models;

namespace MvcTest.Controllers
{
    public class MembersController : Controller
    {
        private IMemberRepository _rep;

        ////デフォルトコンストラクター(標準のリポジトリを設定
        //public MembersController() : this(new MemberRepository())
        //{
        //}

        //テスト用のコンストラクター(あとでダミーのリポジトリをセット)
        public MembersController(IMemberRepository rep)
        {
            _rep = rep;
        }

        // GET: Members
        public ActionResult Index()
        {
            return View(_rep.GetAll());
        }

        //// GET: Members/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Member member = db.Members.Find(id);
        //    if (member == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(member);
        //}

        // GET: Members/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Members/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,Birth,Married,Memo")] Member member)
        {
            if (ModelState.IsValid)
            {
                //リポジトリを利用してメンバー情報を登録
                _rep.Create(member);
                return RedirectToAction("Index");
            }

            return View(member);
        }

        //// GET: Members/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Member member = db.Members.Find(id);
        //    if (member == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(member);
        //}

        //// POST: Members/Edit/5
        //// 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        //// 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Name,Email,Birth,Married,Memo")] Member member)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(member).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(member);
        //}

        //// GET: Members/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Member member = db.Members.Find(id);
        //    if (member == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(member);
        //}

        //// POST: Members/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Member member = db.Members.Find(id);
        //    db.Members.Remove(member);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            //if (disposing)
            //{
            //    db.Dispose();
            //}
            base.Dispose(disposing);
        }
    }
}
