namespace Music.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedArtistsToAlbumView : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.AlbumArtist", "AlbumId");
            AddForeignKey("dbo.AlbumArtist", "AlbumId", "dbo.Album", "AlbumId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AlbumArtist", "AlbumId", "dbo.Album");
            DropIndex("dbo.AlbumArtist", new[] { "AlbumId" });
        }
    }
}
