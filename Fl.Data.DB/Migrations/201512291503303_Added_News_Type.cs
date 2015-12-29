namespace Fl.Data.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_News_Type : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NewsPosts", "NewsType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.NewsPosts", "NewsType");
        }
    }
}
