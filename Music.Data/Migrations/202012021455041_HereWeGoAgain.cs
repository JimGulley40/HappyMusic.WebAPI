namespace Music.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HereWeGoAgain : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FavoriteArtist", "ProfileId", "dbo.Profile");
            DropIndex("dbo.FavoriteArtist", new[] { "ProfileId" });
            AddColumn("dbo.Artist", "Profile_ProfileId", c => c.Int());
            AddColumn("dbo.Profile", "OwnerId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Artist", "Profile_ProfileId");
            AddForeignKey("dbo.Artist", "Profile_ProfileId", "dbo.Profile", "ProfileId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Artist", "Profile_ProfileId", "dbo.Profile");
            DropIndex("dbo.Artist", new[] { "Profile_ProfileId" });
            DropColumn("dbo.Profile", "OwnerId");
            DropColumn("dbo.Artist", "Profile_ProfileId");
            CreateIndex("dbo.FavoriteArtist", "ProfileId");
            AddForeignKey("dbo.FavoriteArtist", "ProfileId", "dbo.Profile", "ProfileId", cascadeDelete: true);
        }
    }
}
