using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Music.Data;
using Music.Models;

namespace Music.Services
{
   
    public class PlaylistServices
    {
        private readonly Guid _userId;

        public PlaylistServices(Guid userId)
        {
            _userId = userId;
        }
        public bool CreatePlaylist(PlaylistCreate model)
        {
            var entity =
                new Playlist()
                {
                    OwnerId = _userId,
                    SongId = model.SongId,
                    PlaylistName = model.PlaylistName,
                    CreatedUtc = DateTimeOffset.Now


                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Playlist.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public bool UpdatePlaylist(PlaylistEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Playlist
                        .Single(e => e.PlaylistId == model.PlaylistId && e.OwnerId == _userId);
                entity.PlaylistName = model.PlaylistName;
                entity.PlaylistId = model.PlaylistId;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }


        public IEnumerable<PlaylistListItem> GetPlayLists()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Playlist
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new PlaylistListItem
                                {
                                    
                                    PlaylistId = e.PlaylistId,
                                    Playlistname = e.PlaylistName,
                                    CreatedUtc = e.CreatedUtc,
                                    NumberOfSongs=e.PlaylistSong.Count,
                                    Songs=e.PlaylistSong

                                }
                        );

                return query.ToArray();
            }
        }
        public PlaylistDetail GetPlaylistById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Playlist
                        .Single(e => e.PlaylistId == id && e.OwnerId == _userId);
                return
                    new PlaylistDetail
                    {
                        PlaylistId = entity.PlaylistId,
                        Playlistname = entity.PlaylistName,
                       
                        NumberOfSongs = entity.NumberOfSongs
                    };
            }
        }

        public bool DeletePlaylist(int playlistId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Playlist
                        .Single(e => e.PlaylistId == playlistId && e.OwnerId == _userId);

                ctx.Playlist.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
