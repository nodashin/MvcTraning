using System.Data.Entity;

namespace MvcRoute.Models
{
  public class MvcRouteContext : DbContext
  {
    public DbSet<Article> Articles { get; set; }
    public DbSet<Comment> Comments { get; set; }
  }
}