namespace Music.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedForeignKeyToAlbumArtistTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AlbumArtist",
                c => new
                    {
                        AlbumArtistId = c.Int(nullable: false, identity: true),
                        AlbumId = c.Int(nullable: false),
                        ArtistId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AlbumArtistId);
            
            AddColumn("dbo.Album", "AlbumArtist_AlbumArtistId", c => c.Int());
            AddColumn("dbo.Artist", "AlbumArtist_AlbumArtistId", c => c.Int());
            CreateIndex("dbo.Album", "AlbumArtist_AlbumArtistId");
            CreateIndex("dbo.Artist", "AlbumArtist_AlbumArtistId");
            AddForeignKey("dbo.Album", "AlbumArtist_AlbumArtistId", "dbo.AlbumArtist", "AlbumArtistId");
            AddForeignKey("dbo.Artist", "AlbumArtist_AlbumArtistId", "dbo.AlbumArtist", "AlbumArtistId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Artist", "AlbumArtist_AlbumArtistId", "dbo.AlbumArtist");
            DropForeignKey("dbo.Album", "AlbumArtist_AlbumArtistId", "dbo.AlbumArtist");
            DropIndex("dbo.Artist", new[] { "AlbumArtist_AlbumArtistId" });
            DropIndex("dbo.Album", new[] { "AlbumArtist_AlbumArtistId" });
            DropColumn("dbo.Artist", "AlbumArtist_AlbumArtistId");
            DropColumn("dbo.Album", "AlbumArtist_AlbumArtistId");
            DropTable("dbo.AlbumArtist");
        }
    }
}
