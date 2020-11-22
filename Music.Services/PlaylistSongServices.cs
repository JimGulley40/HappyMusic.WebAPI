using Music.Data;
using Music.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Services
{
    public class PlaylistSongServices
    {
        private readonly Guid _userId;

        public PlaylistSongServices(Guid userId)
        {
            _userId = userId;
        }
        public bool CreatePlaylistSong(PlaylistSongCreate model)
        {
            var entity =
                new PlaylistSong()
                {
                    PlaylistOwnerId = _userId,
                    
                    PlaylistId = model.PlaylistId,
                    


                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.PlaylistSong.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
       


        public IEnumerable<PlaylistSongListItem> GetPlayListSongs()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .PlaylistSong
                        .Where(e => e.PlaylistOwnerId == _userId)
                        .Select(
                            e =>
                                new PlaylistSongListItem
                                {
                                    PlaylistSongId =e.PlaylistSongId,
                                    PlaylistId = e.PlaylistId,
                                   

                                    
                                }
                        );

                return query.ToArray();
            }
        }
        public PlaylistSongDetail GetPlaylistSongById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .PlaylistSong
                        .Single(e => e.PlaylistId == id && e.PlaylistOwnerId == _userId);
                return
                    new PlaylistSongDetail
                    {
                        PlaylistId = entity.PlaylistId,
                        
                        
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        public bool DeletePlaylistSong(int noteId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .PlaylistSong
                        .Single(e => e.PlaylistSongId == noteId && e.PlaylistOwnerId == _userId);

                ctx.PlaylistSong.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
