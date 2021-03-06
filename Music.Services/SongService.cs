﻿using Music.Data;
using Music.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Music.Services
{

    public class SongService
    {
        //private readonly Guid _userId;

        //public SongService(Guid userId)
        //{
        //    _userId = userId;
        //}
        public bool CreateSong(SongCreate model)
        {
            var entity =
                new Song()
                {
                    //SongOwnerId = _userId,

                    AlbumID = model.AlbumID,
                    Title = model.Title,
                    Lyrics = model.Lyrics,
                    IsExplicit = model.IsExplicit,
                    
                    AlbumName = model.AlbumName,
                    ProfileId = model.ProfileId

                   // PlaylistId = model.PlaylistId
                   
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Songs.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<SongListItem> GetSongs()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Songs
                        //.Where(e => e.SongOwnerId == _userId)

                        .Select(
                            e =>
                                new SongListItem
                                {
                                    SongId = e.SongId,
                                    Title = e.Title,
                                    AlbumName = e.Album.Title,
                                    Artist = e.Album.Artist.ArtistName
                                    
                                    //PlaylistName =e.PlaylistId
                                }
                        );

                return query.ToArray();
            }
        }
        public SongDetail GetSongById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Songs
                        .Single(e => e.SongId == id );
                return
                    new SongDetail
                    {
                        SongId = entity.SongId,
                        Title = entity.Title,
                        Lyrics = entity.Lyrics,
                        IsExplicit = entity.IsExplicit,
                        //CreatedUtc = entity.CreatedUtc,
                        //ModifiedUtc = entity.ModifiedUtc,
                       
                        AlbumName = entity.Album.Title

                    };
            }

        }
        public bool UpdateSong(SongEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Songs
                        .Single(e => e.SongId == model.SongId );

                entity.Title = model.Title;
                entity.AlbumID = model.AlbumId;
                entity.ProfileId = model.ProfileId;
               // entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }
        // not putting a way to change the album title in here, you can only change
        //the album to which the song belongs
        public bool DeleteSong(int songId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Songs
                        .Single(e => e.SongId == songId);

                ctx.Songs.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}