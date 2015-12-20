namespace DataModel.VisitCardContextMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerInfo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                        Surname = c.String(nullable: false, maxLength: 25),
                        Profession = c.String(nullable: false, maxLength: 40),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VisitCardModel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                        Info_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CustomerInfo", t => t.Info_Id, cascadeDelete: true)
                .Index(t => t.Info_Id);
            
            CreateTable(
                "dbo.VisitCardModelCustomerProfiles",
                c => new
                    {
                        VisitCardModel_Id = c.Int(nullable: false),
                        CustomerProfile_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.VisitCardModel_Id, t.CustomerProfile_Id })
                .ForeignKey("dbo.VisitCardModel", t => t.VisitCardModel_Id, cascadeDelete: true)
                .ForeignKey("dbo.CustomerProfile", t => t.CustomerProfile_Id, cascadeDelete: true)
                .Index(t => t.VisitCardModel_Id)
                .Index(t => t.CustomerProfile_Id);
            
            CreateTable(
                "dbo.CustomerProfile",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Birthday = c.DateTime(nullable: false),
                        Login = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CustomerInfo", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerProfile", "Id", "dbo.CustomerInfo");
            DropForeignKey("dbo.VisitCardModelCustomerProfiles", "CustomerProfile_Id", "dbo.CustomerProfile");
            DropForeignKey("dbo.VisitCardModelCustomerProfiles", "VisitCardModel_Id", "dbo.VisitCardModel");
            DropForeignKey("dbo.VisitCardModel", "Info_Id", "dbo.CustomerInfo");
            DropIndex("dbo.CustomerProfile", new[] { "Id" });
            DropIndex("dbo.VisitCardModelCustomerProfiles", new[] { "CustomerProfile_Id" });
            DropIndex("dbo.VisitCardModelCustomerProfiles", new[] { "VisitCardModel_Id" });
            DropIndex("dbo.VisitCardModel", new[] { "Info_Id" });
            DropTable("dbo.CustomerProfile");
            DropTable("dbo.VisitCardModelCustomerProfiles");
            DropTable("dbo.VisitCardModel");
            DropTable("dbo.CustomerInfo");
        }
    }
}
