using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcTest.Models;

namespace MvcTest.Tests.Models
{
    public class MemberTestRepository : IMemberRepository
    {
        public Member Create(Member member)
        {
            //引数の値をそのまま戻す(なにもしない)
            return member;
        }

        public IEnumerable<Member> GetAll()
        {
            //ダミーのMemberオブジェクトを5件作成
            var list = new List<Member>();

            for (int i = 0; i < 5; i++)
            {
                list.Add(
                    new Member()
                    {
                        Id = i,
                        Name = "権兵衛" + i.ToString(),
                        Email = i.ToString() + "test@exsamples.com",
                        Birth = DateTime.Now.AddDays(i),
                        Married = i%2 == 0? true : false,
                        Memo = "メモ" + i.ToString()
                    });
            }

            return list;
        }
    }
}
