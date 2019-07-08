using System.Collections.Generic;

namespace MvcTest.Models
{
  public interface IMemberRepository
  {
    IEnumerable<Member> GetAll();
    Member Create(Member member);
  }
}
