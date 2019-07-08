using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcModel.Models
{
    public class MvcModelContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Person> People { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Article>()
        //        //テーブル名/主キーの関連付け
        //        .ToTable("Contents")
        //        .HasKey(a => a.Url)
        //        //Urlプロパティに対応する列名、最大長を設定
        //        .Property(a => a.Url)
        //        .HasColumnName("Address")
        //        .HasMaxLength(200);
        //}
    }
}