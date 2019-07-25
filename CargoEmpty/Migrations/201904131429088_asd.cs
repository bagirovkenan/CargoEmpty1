namespace CargoEmpty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NewsDbModels", "ImagePath", c => c.String());
            DropColumn("dbo.NewsDbModels", "NewsImagePath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NewsDbModels", "NewsImagePath", c => c.String());
            DropColumn("dbo.NewsDbModels", "ImagePath");
        }
    }
}
