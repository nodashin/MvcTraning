using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcController.Models
{
    public class MvcControllerContext : DbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet <AccessLog> AccessLogs { get; set; }
        public DbSet<ErrorLog> ErrorLogs { get; set; }
    }
}