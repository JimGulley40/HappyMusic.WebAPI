namespace Music.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gavePlaylistsKeyAndNameProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlayList", "PlaylistName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PlayList", "PlaylistName");
        }
    }
}
