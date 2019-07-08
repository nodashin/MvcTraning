namespace MvcModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAddressToAuthors : DbMigration
    {
        public override void Up()
        {
          AddColumn("dbo.Authors", "Address", c => c.String(defaultValue: "Unknown"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Authors", "Address");
        }
    }
}
