using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcTest.Models
{
    public class MvcTestContext : DbContext
    {
        public DbSet<Member> Members { get; set; }
    }
}