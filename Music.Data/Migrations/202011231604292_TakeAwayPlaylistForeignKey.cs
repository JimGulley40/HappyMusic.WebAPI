namespace Music.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TakeAwayPlaylistForeignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Song", "PlaylistId", "dbo.Playlist");
            DropIndex("dbo.Song", new[] { "PlaylistId" });
            DropColumn("dbo.Song", "PlaylistId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Song", "PlaylistId", c => c.Int(nullable: false));
            CreateIndex("dbo.Song", "PlaylistId");
            AddForeignKey("dbo.Song", "PlaylistId", "dbo.Playlist", "PlaylistId", cascadeDelete: true);
        }
    }
}
