namespace ProductsApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Countries", "CurrencyId", "dbo.Currencies");
            DropIndex("dbo.Countries", new[] { "CurrencyId" });
            DropTable("dbo.Countries");
            DropTable("dbo.Currencies");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Currencies",
                c => new
                    {
                        CurrencyId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Category = c.String(),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.CurrencyId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryId = c.Int(nullable: false, identity: true),
                        CurrencyId = c.Int(nullable: false),
                        CountryName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CountryId);
            
            CreateIndex("dbo.Countries", "CurrencyId");
            AddForeignKey("dbo.Countries", "CurrencyId", "dbo.Currencies", "CurrencyId", cascadeDelete: true);
        }
    }
}
