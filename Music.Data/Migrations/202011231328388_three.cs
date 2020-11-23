namespace Music.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class three : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Song", "PlaylistName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Song", "PlaylistName");
        }
    }
}
