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
                            Artist = e.Artist.Select(
                                r =>
                                new ArtistDetail
                                {
                                    ArtistName = r.ArtistName,
                                    ArtistId = r.ArtistId 

                                }).ToList(),

                            Albums = e.Album.Select(
                                b =>
                                new AlbumDetail
                                {
                                    AlbumId = b.AlbumId,
                                    Title = b.Title,
                                    Genre = b.Genre
                                }).ToList()
                             
                        }) ;
                return query.ToArray();
            }
        }
    }
}
