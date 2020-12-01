using Music.Data;
using Music.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Services
{
    public class FavoriteArtistService
    {
        public bool CreateFavoriteArtist(FavoriteArtistCreate model)
        {
            var entity =
                new FavoriteArtist()
                {
                   ProfileId=model.ProfileId,
                   ArtistId = model.ArtistId,
                    FavoriteArtistId=model.FavoriteArtistId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.FavoriteArtist.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<FavoriteArtistListItem> GetFavoriteArtists()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .FavoriteArtist
                        

                        .Select(
                            e =>
                                new FavoriteArtistListItem
                                {
                                   FavoriteArtistId=e.FavoriteArtistId,
                                   ArtistId = e.ArtistId,
                                   ProfileId =e.ProfileId

                                    
                                }
                        );

                return query.ToArray();
            }
        }
        public FavoriteArtistDetail GetFavoriteArtistById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .FavoriteArtist
                        .Single(e => e.FavoriteArtistId == id);
                return
                    new FavoriteArtistDetail
                    {
                       FavoriteArtistId=entity.FavoriteArtistId,
                       ProfileId = entity.ProfileId,
                       ArtistId = entity.ArtistId

                    };
            }

        }
    }
}
