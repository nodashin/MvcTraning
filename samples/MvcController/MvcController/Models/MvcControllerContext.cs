using System.Data.Entity;

namespace MvcController.Models
{
  public class MvcControllerContext : DbContext
  {
    public DbSet<Member> Members { get; set; }
    public DbSet<Article> Articles { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<ErrorLog> ErrorLogs { get; set; }
    public DbSet<AccessLog> AccessLogs { get; set; }
  }
}