using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Music.Data;
using Music.Models;

namespace Music.Services
{
   //this is the Playlist Service, includes all the CRUD methods that are used in the controller
   //level.
    public class PlaylistServices
    {
        //private readonly Guid _userId;

        //public PlaylistServices(Guid userId)
        //{
        //    _userId = userId;
        //}


        //Create Method for CRUD. Takes information put into postman/api and puts it into the format of a playlist

        public bool CreatePlaylist(PlaylistCreate model)
        {
            var entity =
                new Playlist()
                {
                   // OwnerId = _userId,
                    SongId = model.SongId,
                    PlaylistName = model.PlaylistName,
                    CreatedUtc = DateTimeOffset.Now,
                    

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Playlist.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //Update part of CRUD for playlist. Updates the playlist that matches with the input/playlist number put into 
        //postman. Takes all of the old items and turns them into the new updated ones
        public bool UpdatePlaylist(PlaylistEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Playlist
                        .Single(e => e.PlaylistId == model.PlaylistId /*&& e.OwnerId == _userId*/);
                entity.PlaylistName = model.PlaylistName;
                entity.PlaylistId = model.PlaylistId;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        //Read part of crud. This playlist list item references another table of playlist songs, it reads the songs from the playlist song
        //list item and shows the number of songs with their names on the playlist
        public IEnumerable<PlaylistListItem> GetPlayLists()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Playlist
                        //.Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new PlaylistListItem
                                {
                                    
                                    PlaylistId = e.PlaylistId,
                                    Playlistname = e.PlaylistName,
                                    CreatedUtc = e.CreatedUtc,
                                    NumberOfSongs=e.PlaylistSong.Count,
                                    PlaylistSongs = e.PlaylistSong
                                    .Select(
                                       b =>
                                            new PlaylistSongListItem
                                            {
                                                SongId=b.Song.SongId,
                                                Title=b.Song.Title

                                            }).ToList(),


                                }
                        );
                var quer =
                   ctx
                       .Songs
                       // .Where(e => e.PlaylistOwnerId == _userId)
                       .Select(
                           e =>
                               new PlaylistSongListItem
                               {
                                    // PlaylistId = e.PlaylistId,
                                    // PlaylistSongId = e.PlaylistSongId,
                                    SongId = e.SongId,
                                   Title = e.Title,
                                    // Songs=e.Song
                                }
                       );

                return query.ToArray();
            }
        }

        //Read method by id
        public PlaylistDetail GetPlaylistById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Playlist
                        .Single(e => e.PlaylistId == id /* && e.OwnerId == _userId*/);
                return
                    new PlaylistDetail
                    {
                        PlaylistId = entity.PlaylistId,
                        Playlistname = entity.PlaylistName,
                       
                        NumberOfSongs = entity.NumberOfSongs
                    };
            }
        }


        //Delete method of CRUD. Only deletes the playlist ID that matches with the one put into postman
        public bool DeletePlaylist(int playlistId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Playlist
                        .Single(e => e.PlaylistId == playlistId /*&& e.OwnerId == _userId*/);

                ctx.Playlist.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
