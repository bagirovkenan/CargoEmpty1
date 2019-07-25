namespace CargoEmpty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyAdress : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MyAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        State = c.String(),
                        AddressLine1 = c.String(),
                        AddressLine2 = c.String(),
                        ZIPcode = c.String(),
                        City = c.String(),
                        PhoneNumber = c.String(),
                        Semt = c.String(),
                        Ilce = c.String(),
                        IDNumber = c.String(),
                        Addressheader = c.String(),
                        TaxIDNumber = c.String(),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MyAddresses", "CountryId", "dbo.Countries");
            DropIndex("dbo.MyAddresses", new[] { "CountryId" });
            DropTable("dbo.MyAddresses");
        }
    }
}
