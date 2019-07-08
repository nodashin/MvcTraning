using System.Data.Entity;

namespace MvcOther.Models
{
  public class MvcOtherContext : DbContext
  {
    public DbSet<Member> Members { get; set; }
  }
}