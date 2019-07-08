namespace MvcModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                        Title = c.String(),
                        Category = c.Int(nullable: false),
                        Description = c.String(),
                        Viewcount = c.Int(nullable: false),
                        Published = c.DateTime(nullable: false),
                        Released = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Birth = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Body = c.String(),
                        Updated = c.DateTime(nullable: false),
                        ArticleId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Articles", t => t.ArticleId)
                .Index(t => t.ArticleId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Prefecture = c.String(),
                        Address_City = c.String(),
                        Address_Street = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AuthorArticles",
                c => new
                    {
                        Author_Id = c.Int(nullable: false),
                        Article_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Author_Id, t.Article_Id })
                .ForeignKey("dbo.Authors", t => t.Author_Id, cascadeDelete: true)
                .ForeignKey("dbo.Articles", t => t.Article_Id, cascadeDelete: true)
                .Index(t => t.Author_Id)
                .Index(t => t.Article_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "ArticleId", "dbo.Articles");
            DropForeignKey("dbo.AuthorArticles", "Article_Id", "dbo.Articles");
            DropForeignKey("dbo.AuthorArticles", "Author_Id", "dbo.Authors");
            DropIndex("dbo.AuthorArticles", new[] { "Article_Id" });
            DropIndex("dbo.AuthorArticles", new[] { "Author_Id" });
            DropIndex("dbo.Comments", new[] { "ArticleId" });
            DropTable("dbo.AuthorArticles");
            DropTable("dbo.People");
            DropTable("dbo.Comments");
            DropTable("dbo.Authors");
            DropTable("dbo.Articles");
        }
    }
}
