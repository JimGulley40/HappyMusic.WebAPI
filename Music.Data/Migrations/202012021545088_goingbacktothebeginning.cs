namespace Music.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class goingbacktothebeginning : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Profile", "OwnerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Profile", "OwnerId", c => c.Guid(nullable: false));
        }
    }
}
