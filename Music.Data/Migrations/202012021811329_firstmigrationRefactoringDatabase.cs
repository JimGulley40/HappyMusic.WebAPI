namespace Music.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstmigrationRefactoringDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AlbumArtist",
                c => new
                    {
                        AlbumArtistId = c.Int(nullable: false, identity: true),
                        AlbumId = c.Int(nullable: false),
                        ArtistId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AlbumArtistId)
                .ForeignKey("dbo.Album", t => t.AlbumId, cascadeDelete: true)
                .Index(t => t.AlbumId);
            
            CreateTable(
                "dbo.Album",
                c => new
                    {
                        AlbumId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Genre = c.Int(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        ArtistID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AlbumId)
                .ForeignKey("dbo.Artist", t => t.ArtistID, cascadeDelete: true)
                .Index(t => t.ArtistID);
            
            CreateTable(
                "dbo.Artist",
                c => new
                    {
                        ArtistId = c.Int(nullable: false, identity: true),
                        ArtistName = c.String(nullable: false),
                        OwnerId = c.Guid(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.ArtistId);
            
            CreateTable(
                "dbo.Song",
                c => new
                    {
                        SongId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        AlbumName = c.String(),
                        AlbumID = c.Int(nullable: false),
                        Lyrics = c.String(nullable: false),
                        ProfileId = c.Int(nullable: false),
                        IsExplicit = c.Boolean(nullable: false),
                        PlaylistName = c.String(),
                    })
                .PrimaryKey(t => t.SongId)
                .ForeignKey("dbo.Album", t => t.AlbumID, cascadeDelete: true)
                .ForeignKey("dbo.Profile", t => t.ProfileId, cascadeDelete: true)
                .Index(t => t.AlbumID)
                .Index(t => t.ProfileId);
            
            CreateTable(
                "dbo.Profile",
                c => new
                    {
                        ProfileId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        MembershipLevel = c.Int(nullable: false),
                        RenewalDate = c.DateTime(nullable: false),
                        Email = c.String(),
                        ContactPreference = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProfileId);
            
            CreateTable(
                "dbo.FavoriteArtist",
                c => new
                    {
                        FavoriteArtistId = c.Int(nullable: false, identity: true),
                        ArtistId = c.Int(nullable: false),
                        ProfileId = c.Int(nullable: false),
                        ArtistName = c.String(),
                    })
                .PrimaryKey(t => t.FavoriteArtistId)
                .ForeignKey("dbo.Artist", t => t.ArtistId, cascadeDelete: true)
                .ForeignKey("dbo.Profile", t => t.ProfileId, cascadeDelete: true)
                .Index(t => t.ArtistId)
                .Index(t => t.ProfileId);
            
            CreateTable(
                "dbo.Playlist",
                c => new
                    {
                        PlaylistId = c.Int(nullable: false, identity: true),
                        SongId = c.Int(nullable: false),
                        PlaylistName = c.String(),
                        ProfileID = c.Int(nullable: false),
                        OwnerId = c.Guid(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.PlaylistId);
            
            CreateTable(
                "dbo.PlaylistSong",
                c => new
                    {
                        PlaylistSongId = c.Int(nullable: false, identity: true),
                        PlaylistId = c.Int(nullable: false),
                        SongId = c.Int(nullable: false),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.PlaylistSongId)
                .ForeignKey("dbo.Playlist", t => t.PlaylistId, cascadeDelete: true)
                .Index(t => t.PlaylistId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.PlaylistSong", "PlaylistId", "dbo.Playlist");
            DropForeignKey("dbo.Song", "ProfileId", "dbo.Profile");
            DropForeignKey("dbo.FavoriteArtist", "ProfileId", "dbo.Profile");
            DropForeignKey("dbo.FavoriteArtist", "ArtistId", "dbo.Artist");
            DropForeignKey("dbo.Song", "AlbumID", "dbo.Album");
            DropForeignKey("dbo.Album", "ArtistID", "dbo.Artist");
            DropForeignKey("dbo.AlbumArtist", "AlbumId", "dbo.Album");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.PlaylistSong", new[] { "PlaylistId" });
            DropIndex("dbo.FavoriteArtist", new[] { "ProfileId" });
            DropIndex("dbo.FavoriteArtist", new[] { "ArtistId" });
            DropIndex("dbo.Song", new[] { "ProfileId" });
            DropIndex("dbo.Song", new[] { "AlbumID" });
            DropIndex("dbo.Album", new[] { "ArtistID" });
            DropIndex("dbo.AlbumArtist", new[] { "AlbumId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.PlaylistSong");
            DropTable("dbo.Playlist");
            DropTable("dbo.FavoriteArtist");
            DropTable("dbo.Profile");
            DropTable("dbo.Song");
            DropTable("dbo.Artist");
            DropTable("dbo.Album");
            DropTable("dbo.AlbumArtist");
        }
    }
}
