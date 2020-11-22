namespace Music.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatingAlbumToRunPostman : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Album", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Album", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Album", "CreatedUtc");
            DropColumn("dbo.Album", "OwnerId");
        }
    }
}
