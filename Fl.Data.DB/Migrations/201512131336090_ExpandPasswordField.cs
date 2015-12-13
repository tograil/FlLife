namespace Fl.Data.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExpandPasswordField : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Logins", "Password", c => c.String(nullable: false, maxLength: 130));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Logins", "Password", c => c.String(nullable: false, maxLength: 30));
        }
    }
}
