﻿using Music.Data;
using Music.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Music.Services
{

    //This is our Artist Service , it pulls from the Artist models to read the CRUD
    //methods for this layer. 
    public class ArtistService
    {
        //private readonly Guid _userId;

        //public ArtistService(Guid userId)
        //{
        //    _userId = userId;
        //}

        //CRUD Create for artist-- only thing needed is the name of the artist from the artist table
        public bool CreateArtist(ArtistCreate model)
        {
            var entity =
                new Artist()
                {
                    //OwnerId = _userId,
                    ArtistName = model.ArtistName,
                    //CreatedUtc = DateTimeOffset.Now,
                    //IsFavoriteArtist=model.IsFavoriteArtist
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Artists.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //Read method for CRUD , takes items found in model LISTITEM and converts them into
        //a viewable type of artist

        //The new artistListitme passes the artist id from the artist table and moves it into a readable list for
        //the api
        public IEnumerable<ArtistListItem> GetArtists()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Artists
                        /*.Where(e => e.OwnerId == _userId)*/
                        .Select(
                            e =>
                                new ArtistListItem
                                {
                                    ArtistId = e.ArtistId,
                                    ArtistName = e.ArtistName,
                                    //CreatedUtc = e.CreatedUtc,
                                    //IsFavoriteArtist = e.IsFavoriteArtist
                                }
                        );

                return query.ToArray();
            }
        }

        // This gets artists by ID and returns the correct artist-- it only returns the artist details that is specified below
        public ArtistDetail GetArtistById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Artists
                        .Single(e => e.ArtistId == id/* && e.OwnerId == _userId*/);
                return
                    new ArtistDetail
                    {
                        ArtistId = entity.ArtistId,
                        //OwnerId = _userId,
                        ArtistName = entity.ArtistName,
                        CreatedUtc = DateTimeOffset.Now,
                        ModifiedUtc = entity.ModifiedUtc,
                       // IsFavoriteArtist = entity.IsFavoriteArtist
                    };
            }

        }
        //Update method in CRUD, updates the artist that matches with the artist ID in the postman request
        public bool UpdateArtist(ArtistEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Artists
                        .Single(e => e.ArtistId == model.ArtistId /*&& e.OwnerId == _userId)*/);
                //entity.ArtistId = model.ArtistId;
                entity.ArtistName = model.ArtistName;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;
               // entity.IsFavoriteArtist = model.IsFavoriteArtist;

                return ctx.SaveChanges() == 1;
            }
        }

       //Delete in CRUD, deletes the number that is specified in the api/Artist / {HERE}
        public bool DeleteArtist(int songId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Artists
                        .Single(e => e.ArtistId == songId /*&& e.OwnerId == _userId*/);

                ctx.Artists.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}