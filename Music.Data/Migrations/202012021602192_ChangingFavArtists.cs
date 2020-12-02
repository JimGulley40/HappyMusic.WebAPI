namespace Music.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangingFavArtists : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Artist", "Profile_ProfileId", "dbo.Profile");
            DropIndex("dbo.Artist", new[] { "Profile_ProfileId" });
            CreateIndex("dbo.FavoriteArtist", "ProfileId");
            AddForeignKey("dbo.FavoriteArtist", "ProfileId", "dbo.Profile", "ProfileId", cascadeDelete: true);
            DropColumn("dbo.Artist", "Profile_ProfileId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Artist", "Profile_ProfileId", c => c.Int());
            DropForeignKey("dbo.FavoriteArtist", "ProfileId", "dbo.Profile");
            DropIndex("dbo.FavoriteArtist", new[] { "ProfileId" });
            CreateIndex("dbo.Artist", "Profile_ProfileId");
            AddForeignKey("dbo.Artist", "Profile_ProfileId", "dbo.Profile", "ProfileId");
        }
    }
}
