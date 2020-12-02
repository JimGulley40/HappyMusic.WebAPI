namespace Music.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedArtistListToFavArtist : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.FavoriteArtist", "ArtistId");
            AddForeignKey("dbo.FavoriteArtist", "ArtistId", "dbo.Artist", "ArtistId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FavoriteArtist", "ArtistId", "dbo.Artist");
            DropIndex("dbo.FavoriteArtist", new[] { "ArtistId" });
        }
    }
}
