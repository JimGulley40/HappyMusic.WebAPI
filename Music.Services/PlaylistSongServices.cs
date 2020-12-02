
﻿using Music.Data;
using Music.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Services
{
    //This is our PlaylistSong Joiner service, it joins playlist and songs together to show a list of 
    //songs in a playlist. 
    public class PlaylistSongServices
    {
        //private readonly Guid _userId;

        //public PlaylistSongServices(Guid userId)
        //{
        //    _userId = userId;
        //}

        //Create Method in CRUD
        public bool CreatePlaylistSong(PlaylistSongCreate model)
        {
            var entity =
                new PlaylistSong()
                {
                   // PlaylistOwnerId = _userId,
                    SongId = model.SongId,
                    PlaylistId = model.PlaylistId,
                    Title = model.Title


                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.PlaylistSong.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
       

        //Read method in crud by list item. This shows the playlistSong's title and SongID in the request
        public IEnumerable<PlaylistSongListItem> GetPlayListSongs()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Songs
                       // .Where(e => e.PlaylistOwnerId == _userId)
                        .Select(
                            e =>
                                new PlaylistSongListItem
                                {
                                   // PlaylistId = e.PlaylistId,
                                   // PlaylistSongId = e.PlaylistSongId,
                                    SongId =e.SongId,
                                    Title = e.Title,
                                   // Songs=e.Song
                                }
                        );

                return query.ToArray();
            }
        }//Read method in CRUD by id
        public PlaylistSongDetail GetPlaylistSongById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .PlaylistSong
                        .Single(e => e.PlaylistSongId == id /* && e.PlaylistOwnerId == _userId*/);
                return
                    new PlaylistSongDetail
                    {
                        PlaylistId = entity.PlaylistId,
                        PlaylistSongId = entity.PlaylistSongId,
                        SongId = entity.SongId,
                        Title= entity.Title
                    };
            }
        }
        //Delete Method in crud by the ID. If the id put into postman doesn't match the id found in the database, it will not delete the item. 
        public bool DeletePlaylistSong(int noteId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .PlaylistSong
                        .Single(e => e.PlaylistSongId == noteId /*&& e.PlaylistOwnerId == _userId*/);

                ctx.PlaylistSong.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
