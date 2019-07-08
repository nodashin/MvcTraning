namespace MvcOther.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyPageAndTwitterToUsers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "MyPage", c => c.String());
            AddColumn("dbo.AspNetUsers", "Twitter", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Twitter");
            DropColumn("dbo.AspNetUsers", "MyPage");
        }
    }
}
