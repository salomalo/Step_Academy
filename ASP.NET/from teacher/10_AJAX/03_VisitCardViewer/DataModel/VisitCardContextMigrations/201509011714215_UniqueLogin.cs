namespace DataModel.VisitCardContextMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UniqueLogin : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CustomerProfile", "Login", c => c.String(nullable: false, maxLength: 25));
            CreateIndex("dbo.CustomerProfile", "Login", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.CustomerProfile", new[] { "Login" });
            AlterColumn("dbo.CustomerProfile", "Login", c => c.String(nullable: false));
        }
    }
}
