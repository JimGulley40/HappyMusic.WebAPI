namespace Music.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.PlaylistSong", "SongId");
            AddForeignKey("dbo.PlaylistSong", "SongId", "dbo.Song", "SongId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlaylistSong", "SongId", "dbo.Song");
            DropIndex("dbo.PlaylistSong", new[] { "SongId" });
        }
    }
}
