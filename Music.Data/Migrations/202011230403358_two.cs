namespace Music.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class two : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Song", "AlbumID", "dbo.Album");
            DropIndex("dbo.Song", new[] { "AlbumID" });
            RenameColumn(table: "dbo.Song", name: "AlbumID", newName: "Album_AlbumId");
            AlterColumn("dbo.Song", "Album_AlbumId", c => c.Int());
            CreateIndex("dbo.Song", "Album_AlbumId");
            AddForeignKey("dbo.Song", "Album_AlbumId", "dbo.Album", "AlbumId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Song", "Album_AlbumId", "dbo.Album");
            DropIndex("dbo.Song", new[] { "Album_AlbumId" });
            AlterColumn("dbo.Song", "Album_AlbumId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Song", name: "Album_AlbumId", newName: "AlbumID");
            CreateIndex("dbo.Song", "AlbumID");
            AddForeignKey("dbo.Song", "AlbumID", "dbo.Album", "AlbumId", cascadeDelete: true);
        }
    }
}
