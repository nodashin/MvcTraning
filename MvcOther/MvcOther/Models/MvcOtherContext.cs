using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcOther.Models
{
    public class MvcOtherContext : DbContext
    {
        public DbSet<Member> Members { get; set; }
    }
}