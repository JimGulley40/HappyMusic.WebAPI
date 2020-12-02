using Music.Data;
using Music.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Music.Services
{
    //This is our service class to complete CRUD methods for album

    public class AlbumService
    {
        //private readonly Guid _userId;

        //public AlbumService(Guid userId)
        //{
        //    _userId = userId;
        //}


        //Create for CRUD, takes items in CreateModel to make a new album
        public bool CreateAlbum(AlbumCreate model)
        {
            var entity =
                new Album()
                {
                    //OwnerId = _userId,
                    Title = model.Title,
                    Genre = model.Genre,
                    ReleaseDate = model.ReleaseDate,
                    
                    ArtistID =model.ArtistId
                   // Songs = model.Songs
  
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Albums.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //Read item for CRUD, Takes model from LISTITEM and converts any items in 
        //albums table to a List-Item so we can see more clearly the lists
        //also found a way to display a list inside of a list by referencing the details
        //of other songs that have been created. 
        public IEnumerable<AlbumListItem> GetAlbums()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Albums

                        //.Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new AlbumListItem
                                {
                                    AlbumId = e.AlbumId,
                                    Title = e.Title,
                                    Genre = e.Genre.ToString(),
                                    ReleaseDate = e.ReleaseDate,
                                    Songs = e.Songs.Select(
                                        b =>
                                            new SongDetail
                                            {
                                                SongId = b.SongId,
                                                Title = b.Title,
                                                IsExplicit= b.IsExplicit,
                                                Lyrics = b.Lyrics,

                                                AlbumName=b.Album.Title,
                                                ArtistName=b.Album.Artist.ArtistName
                                                
                                                
                                            }).ToList(),
                                    
                                    
                                    
                                }
                        ) ;

                return query.ToArray();
            }
        }
        //This is the same as above, its it READ for CRUD by ID of album
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
        //CRUD Update for album, it takes the album id that is similar to the model id that
        //you are putting in and updates the title
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


        //CRUD for delete album, takes id of album and deletes it based off the id that matches with the album
        //ID that is already on the database. 
       
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