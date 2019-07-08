using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcTest.Models
{
    public interface IMemberRepository
    {
        IEnumerable<Member> GetAll();
        Member Create(Member member);
    }
}
