namespace DataModel.VisitCardContextMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VisitCardReferencedToCust : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VisitCardModelCustomerProfiles", "VisitCardModel_Id", "dbo.VisitCardModel");
            DropForeignKey("dbo.VisitCardModelCustomerProfiles", "CustomerProfile_Id", "dbo.CustomerProfile");
            DropIndex("dbo.VisitCardModelCustomerProfiles", new[] { "VisitCardModel_Id" });
            DropIndex("dbo.VisitCardModelCustomerProfiles", new[] { "CustomerProfile_Id" });
            AddColumn("dbo.CustomerProfile", "VisitCardModel_Id", c => c.Int());
            AddColumn("dbo.CustomerProfile", "OwnCard_Id", c => c.Int());
            AddColumn("dbo.VisitCardModel", "CustomerProfile_Id", c => c.Int());
            CreateIndex("dbo.VisitCardModel", "CustomerProfile_Id");
            CreateIndex("dbo.CustomerProfile", "VisitCardModel_Id");
            CreateIndex("dbo.CustomerProfile", "OwnCard_Id");
            AddForeignKey("dbo.VisitCardModel", "CustomerProfile_Id", "dbo.CustomerProfile", "Id");
            AddForeignKey("dbo.CustomerProfile", "VisitCardModel_Id", "dbo.VisitCardModel", "Id");
            AddForeignKey("dbo.CustomerProfile", "OwnCard_Id", "dbo.VisitCardModel", "Id");
            DropTable("dbo.VisitCardModelCustomerProfiles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.VisitCardModelCustomerProfiles",
                c => new
                    {
                        VisitCardModel_Id = c.Int(nullable: false),
                        CustomerProfile_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.VisitCardModel_Id, t.CustomerProfile_Id });
            
            DropForeignKey("dbo.CustomerProfile", "OwnCard_Id", "dbo.VisitCardModel");
            DropForeignKey("dbo.CustomerProfile", "VisitCardModel_Id", "dbo.VisitCardModel");
            DropForeignKey("dbo.VisitCardModel", "CustomerProfile_Id", "dbo.CustomerProfile");
            DropIndex("dbo.CustomerProfile", new[] { "OwnCard_Id" });
            DropIndex("dbo.CustomerProfile", new[] { "VisitCardModel_Id" });
            DropIndex("dbo.VisitCardModel", new[] { "CustomerProfile_Id" });
            DropColumn("dbo.VisitCardModel", "CustomerProfile_Id");
            DropColumn("dbo.CustomerProfile", "OwnCard_Id");
            DropColumn("dbo.CustomerProfile", "VisitCardModel_Id");
            CreateIndex("dbo.VisitCardModelCustomerProfiles", "CustomerProfile_Id");
            CreateIndex("dbo.VisitCardModelCustomerProfiles", "VisitCardModel_Id");
            AddForeignKey("dbo.VisitCardModelCustomerProfiles", "CustomerProfile_Id", "dbo.CustomerProfile", "Id", cascadeDelete: true);
            AddForeignKey("dbo.VisitCardModelCustomerProfiles", "VisitCardModel_Id", "dbo.VisitCardModel", "Id", cascadeDelete: true);
        }
    }
}
