using System.Collections.Generic;

namespace MvcTest.Models
{
  public class MemberRepository : IMemberRepository
  {
    private MvcTestContext db = new MvcTestContext();

    public IEnumerable<Member> GetAll()
    {
      return db.Members;
    }

    public Member Create(Member member)
    {
      db.Members.Add(member);
      db.SaveChanges();
      return member;
    }
  }
}