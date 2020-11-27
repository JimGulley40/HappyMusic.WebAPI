using Music.Data;
using Music.Models;
using Music.Models.AlbumArtistFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Services
{
    public class AlbumArtistService
    {
        public bool CreateAlbumArtist(AlbumArtistCreate model)
        {
            var entity =
                new AlbumArtist()
                {
                    
                    AlbumId = model.AlbumId,
                    ArtistId = model.ArtistId
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.AlbumArtist.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<AlbumArtistListItem> GetAlbumArtists()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .AlbumArtist
                    .Select(
                        e =>
                        new AlbumArtistListItem
                        {
                            
                            AlbumId = e.AlbumId,
                            ArtistId = e.ArtistId
                             
                        }) ;
                return query.ToArray();
            }
        }
    }
}
