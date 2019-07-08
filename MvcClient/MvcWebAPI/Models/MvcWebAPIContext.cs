using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcWebAPI.Models
{
    public class MvcWebAPIContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
    }
}