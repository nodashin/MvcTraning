using System.Data.Entity;

namespace MvcBasic.Models
{
  public class MvcBasicContext : DbContext
  {
    public DbSet<Member> Members { get; set; }
  }
}