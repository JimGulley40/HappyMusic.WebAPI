namespace Music.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovingForeignKeysAround : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Album", "Artist_ArtistId", c => c.Int());
            CreateIndex("dbo.Album", "Artist_ArtistId");
            AddForeignKey("dbo.Album", "Artist_ArtistId", "dbo.Artist", "ArtistId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Album", "Artist_ArtistId", "dbo.Artist");
            DropIndex("dbo.Album", new[] { "Artist_ArtistId" });
            DropColumn("dbo.Album", "Artist_ArtistId");
        }
    }
}
