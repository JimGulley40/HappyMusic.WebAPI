namespace Music.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlbumArtistTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Album", "AlbumArtist_AlbumArtistId", "dbo.AlbumArtist");
            DropForeignKey("dbo.Artist", "AlbumArtist_AlbumArtistId", "dbo.AlbumArtist");
            DropIndex("dbo.Album", new[] { "AlbumArtist_AlbumArtistId" });
            DropIndex("dbo.Artist", new[] { "AlbumArtist_AlbumArtistId" });
            DropColumn("dbo.Album", "AlbumArtist_AlbumArtistId");
            DropColumn("dbo.Artist", "AlbumArtist_AlbumArtistId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Artist", "AlbumArtist_AlbumArtistId", c => c.Int());
            AddColumn("dbo.Album", "AlbumArtist_AlbumArtistId", c => c.Int());
            CreateIndex("dbo.Artist", "AlbumArtist_AlbumArtistId");
            CreateIndex("dbo.Album", "AlbumArtist_AlbumArtistId");
            AddForeignKey("dbo.Artist", "AlbumArtist_AlbumArtistId", "dbo.AlbumArtist", "AlbumArtistId");
            AddForeignKey("dbo.Album", "AlbumArtist_AlbumArtistId", "dbo.AlbumArtist", "AlbumArtistId");
        }
    }
}
