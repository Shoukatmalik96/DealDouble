namespace DealDouble.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedAucionEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Auctions", "StartingDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Auctions", "StatringDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Auctions", "StatringDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Auctions", "StartingDate");
        }
    }
}
