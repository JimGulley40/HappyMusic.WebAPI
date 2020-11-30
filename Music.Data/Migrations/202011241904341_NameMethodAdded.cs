namespace Music.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NameMethodAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AlbumArtist", "AlbumName", c => c.String());
            AddColumn("dbo.AlbumArtist", "ArtistName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AlbumArtist", "ArtistName");
            DropColumn("dbo.AlbumArtist", "AlbumName");
        }
    }
}
