namespace CargoEmpty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMg : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CaruselDbs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Text = c.String(),
                        ImagePath = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CaruselDbs");
        }
    }
}
