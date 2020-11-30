namespace Music.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovedForeignKeyToArtist : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AlbumArtist", "AlbumId", "dbo.Album");
            DropIndex("dbo.AlbumArtist", new[] { "AlbumId" });
            CreateIndex("dbo.AlbumArtist", "ArtistId");
            AddForeignKey("dbo.AlbumArtist", "ArtistId", "dbo.Artist", "ArtistId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AlbumArtist", "ArtistId", "dbo.Artist");
            DropIndex("dbo.AlbumArtist", new[] { "ArtistId" });
            CreateIndex("dbo.AlbumArtist", "AlbumId");
            AddForeignKey("dbo.AlbumArtist", "AlbumId", "dbo.Album", "AlbumId", cascadeDelete: true);
        }
    }
}
