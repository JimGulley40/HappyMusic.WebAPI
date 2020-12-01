namespace Music.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Music.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Music.Data.ApplicationDbContext";
        }

        protected override void Seed(Music.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
                context.Artists.AddOrUpdate(
                  p => p.ArtistName,
                new Artist  { ArtistName = "Ashley Bain"},
                new Artist  { ArtistName = "Jim Gulley" },
                new Artist  { ArtistName = "Yazid Louda" }
                );
           // context.Songs.AddOrUpdate(
           //      p => p.Title,
            //   new Song { Title = "Ashley's Tune" },
            //   new Song { Title = "Jim's Tune" },
            //   new Song { Title = "Yazid's Tune" }
           //    );




            //
        }
    }
}
