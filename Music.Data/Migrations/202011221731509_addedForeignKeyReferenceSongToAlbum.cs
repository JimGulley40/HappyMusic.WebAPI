namespace Music.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedForeignKeyReferenceSongToAlbum : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Song", "AlbumID", c => c.Int(nullable: false));
            CreateIndex("dbo.Song", "AlbumID");
            AddForeignKey("dbo.Song", "AlbumID", "dbo.Album", "AlbumId", cascadeDelete: true);
            DropColumn("dbo.Song", "OwnerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Song", "OwnerId", c => c.Guid(nullable: false));
            DropForeignKey("dbo.Song", "AlbumID", "dbo.Album");
            DropIndex("dbo.Song", new[] { "AlbumID" });
            AlterColumn("dbo.Song", "AlbumID", c => c.Int());
        }
    }
}
