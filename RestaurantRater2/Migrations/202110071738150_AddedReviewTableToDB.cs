namespace RestaurantRater2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedReviewTableToDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        RestaurantId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.RestaurantId);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ReviewId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Body = c.String(),
                        DineDate = c.DateTime(nullable: false),
                        Rating = c.Int(nullable: false),
                        RestaurantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReviewId)
                .ForeignKey("dbo.Restaurants", t => t.RestaurantId, cascadeDelete: true)
                .Index(t => t.RestaurantId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "RestaurantId", "dbo.Restaurants");
            DropIndex("dbo.Reviews", new[] { "RestaurantId" });
            DropTable("dbo.Reviews");
            DropTable("dbo.Restaurants");
        }
    }
}
