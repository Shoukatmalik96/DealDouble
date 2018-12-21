namespace DealDouble.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedAuctionEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Auctions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        ActualAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StatringDate = c.DateTime(nullable: false),
                        EndingDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Auctions");
        }
    }
}
