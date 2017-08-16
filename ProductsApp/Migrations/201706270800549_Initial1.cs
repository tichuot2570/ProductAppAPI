namespace ProductsApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ContactId);
            
            CreateTable(
                "dbo.Deals",
                c => new
                    {
                        DealId = c.Int(nullable: false, identity: true),
                        LocationId = c.Int(nullable: false),
                        ContactId = c.Int(nullable: false),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.DealId)
                .ForeignKey("dbo.Contacts", t => t.ContactId, cascadeDelete: true)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .Index(t => t.LocationId)
                .Index(t => t.ContactId);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        LocationId = c.Int(nullable: false, identity: true),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.LocationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Deals", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.Deals", "ContactId", "dbo.Contacts");
            DropIndex("dbo.Deals", new[] { "ContactId" });
            DropIndex("dbo.Deals", new[] { "LocationId" });
            DropTable("dbo.Locations");
            DropTable("dbo.Deals");
            DropTable("dbo.Contacts");
        }
    }
}
