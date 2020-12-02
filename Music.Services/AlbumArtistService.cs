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
        //This takes the AlbumArtistCreate listed below and takes the items from AlbumArtist
        //and moves it to another table-- The AlbumArtist is a joiner table that links Albums
        //& artists together

        //Create for CRUD
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
        //Read for CRUD, reads the SQL table created
        //This refers to the model for AlbumListItem to show what we want listed in our API
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
