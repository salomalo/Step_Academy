namespace DataModel.VisitCardContextMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RolesAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerProfile", "Role", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomerProfile", "Role");
        }
    }
}
