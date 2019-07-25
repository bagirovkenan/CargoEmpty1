namespace CargoEmpty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class faqs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FaqDbs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FaqTitle = c.String(),
                        FaqContent = c.String(),
                        FaqCreateDate = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FaqDbs");
        }
    }
}
