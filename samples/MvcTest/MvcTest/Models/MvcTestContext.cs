using System.Data.Entity;

namespace MvcTest.Models
{
  public class MvcTestContext : DbContext
  {
    public DbSet<Member> Members { get; set; }
  }
}