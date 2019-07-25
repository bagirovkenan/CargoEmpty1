namespace CargoEmpty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ds : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.NewsDbModels", "NewsCreateDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.NewsDbModels", "NewsCreateDate", c => c.DateTime(nullable: false));
        }
    }
}
