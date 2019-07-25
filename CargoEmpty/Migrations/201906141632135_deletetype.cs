namespace CargoEmpty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletetype : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DeclerationDbs", "DeclerationTypeId", "dbo.DeclerationTypes");
            DropIndex("dbo.DeclerationDbs", new[] { "DeclerationTypeId" });
            DropColumn("dbo.DeclerationDbs", "DeclerationTypeId");
            DropTable("dbo.DeclerationTypes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DeclerationTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.DeclerationDbs", "DeclerationTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.DeclerationDbs", "DeclerationTypeId");
            AddForeignKey("dbo.DeclerationDbs", "DeclerationTypeId", "dbo.DeclerationTypes", "Id", cascadeDelete: true);
        }
    }
}
