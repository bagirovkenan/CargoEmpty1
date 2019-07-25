namespace CargoEmpty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class category : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ShopDbs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ShopName = c.String(),
                        Link = c.String(),
                        CategoryId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShopDbs", "CategoryId", "dbo.Categories");
            DropIndex("dbo.ShopDbs", new[] { "CategoryId" });
            DropTable("dbo.ShopDbs");
            DropTable("dbo.Categories");
        }
    }
}
