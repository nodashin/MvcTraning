using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcTest.Models
{
    public class MemberRepository : IMemberRepository
    {
        //コンテキストクラスを準備
        private MvcTestContext db = new MvcTestContext();

        //指定されたメンバー情報をデータベースに保存
        public Member Create(Member member)
        {
            db.Members.Add(member);
            db.SaveChanges();
            return member;
        }

        //すべてのメンバー情報を取得
        public IEnumerable<Member> GetAll()
        {
            return db.Members;
        }
    }
}