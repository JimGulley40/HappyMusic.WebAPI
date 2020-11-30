using Music.Data;
using Music.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Music.Services
{


    public class AlbumService
    {
    private readonly ApplicationDbContext _context = new ApplicationDbContext();
        //private readonly Guid _userId;

        //public AlbumService(Guid userId)
        //{
        //    _userId = userId;
        //}
        public async Task<bool> CreateAlbum(AlbumCreate model)
        {
            var entity =
                new Album()
                {
                    //OwnerId = _userId,
                    Title = model.Title,
                    Genre = model.Genre,
                    ReleaseDate = model.ReleaseDate,
                   // Songs = model.Songs
  
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Albums.Add(entity);
                return await ctx.SaveChangesAsync() == 1;
            }
        }
        public async Task< IEnumerable<AlbumListItem>>GetAlbums()
        {

           // using (var ctx = new ApplicationDbContext())
            {
                var query = await _context.Albums.Select(e => new AlbumListItem
                {
                    AlbumId = e.AlbumId,
                    Title = e.Title,
                    Genre = e.Genre,
                    ReleaseDate = e.ReleaseDate,
                    Songs = (List<SongDetail>)e.Songs.Select(b =>new SongDetail
                                           {
                                               SongId = b.SongId,
                                               Title = b.Title,
                                               IsExplicit = b.IsExplicit,
                                               Lyrics = b.Lyrics,

                                               AlbumName = b.Album.Title


                                           }),
                                   Artists = (List<ArtistDetail>)e.Artists.Select(
                                       b =>
                                       new ArtistDetail
                                       {
                                           ArtistId = b.ArtistId,
                                           ArtistName = b.ArtistName,
                                       })



                }).ToListAsync();
                        

                return query.ToArray();
            }
        }
        public AlbumDetail GetAlbumById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Albums
                        .Single(e => e.AlbumId == id /*&& e.OwnerId == _userId*/);
                return
                    new AlbumDetail
                    {
                        AlbumId = entity.AlbumId,
                        //OwnerId = _userId,
                        Title = entity.Title,
                        Genre = entity.Genre,
                        ReleaseDate = entity.ReleaseDate,

                      
                      
                    };
            }

        }
        public bool UpdateAlbum(AlbumEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Albums
                        .Single(e => e.AlbumId == model.AlbumId/* && e.OwnerId == _userId*/);
                //entity.AlbumId = model.AlbumId;
                entity.Title = model.Title;
               

                return ctx.SaveChanges() == 1;
            }
        }

       
        public bool DeleteAlbum(int songId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Albums
                        .Single(e => e.AlbumId == songId /*&& e.OwnerId == _userId*/);

                ctx.Albums.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}