namespace CargoEmpty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteNoTE : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.NewsDbModels", "Note");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NewsDbModels", "Note", c => c.String());
        }
    }
}
