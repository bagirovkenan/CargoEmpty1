namespace CargoEmpty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeorderdbIDindecleration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderDbs", "Decleration_Id", "dbo.DeclerationDbs");
            DropIndex("dbo.OrderDbs", new[] { "Decleration_Id" });
            DropColumn("dbo.DeclerationDbs", "OrderDbId");
            DropColumn("dbo.OrderDbs", "Decleration_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderDbs", "Decleration_Id", c => c.Int());
            AddColumn("dbo.DeclerationDbs", "OrderDbId", c => c.Int());
            CreateIndex("dbo.OrderDbs", "Decleration_Id");
            AddForeignKey("dbo.OrderDbs", "Decleration_Id", "dbo.DeclerationDbs", "Id");
        }
    }
}
