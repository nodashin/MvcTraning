using MvcTest.Models;
using System;
using System.Collections.Generic;


namespace MvcTest.Tests.Models
{
  class MemberTestRepository : IMemberRepository
  {
    public IEnumerable<Member> GetAll()
    {
      var list = new List<Member>();

      for (var i = 0; i < 5; i++)
      {
        list.Add(
          new Member()
          {
            Id = i,
            Name = "権兵衛" + i.ToString(),
            Email = i.ToString() + "test@examples.com",
            Birth = DateTime.Now.AddDays(i),
            Married = i % 2 == 0 ? true : false,
            Memo = "メモ" + i.ToString()
          }
        );
      }
      return list;
    }

    public Member Create(Member member)
    {
      return member;
    }
  }
}
