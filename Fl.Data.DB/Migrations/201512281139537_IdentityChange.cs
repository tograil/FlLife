namespace Fl.Data.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdentityChange : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Logins", "Salt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Logins", "Salt", c => c.String(nullable: false, maxLength: 30));
        }
    }
}
