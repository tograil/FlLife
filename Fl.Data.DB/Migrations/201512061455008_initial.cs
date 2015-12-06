namespace Fl.Data.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Language",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        ShortName = c.String(nullable: false, maxLength: 3),
                        CultureCode = c.String(nullable: false, maxLength: 10),
                        IsActive = c.Boolean(nullable: false),
                        Order = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NewsPosts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 120),
                        Body = c.String(nullable: false),
                        PostDate = c.DateTime(nullable: false),
                        LanguageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Language", t => t.LanguageId, cascadeDelete: true)
                .Index(t => t.LanguageId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NewsPosts", "LanguageId", "dbo.Language");
            DropIndex("dbo.NewsPosts", new[] { "LanguageId" });
            DropTable("dbo.NewsPosts");
            DropTable("dbo.Language");
        }
    }
}
