using Music.Data;
using Music.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Music.Services
{


    public class SongService
    {
        private readonly Guid _userId;

        public SongService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateSong(SongCreate model)
        {
            var entity =
                new Song()
                {
                    OwnerId = _userId,
                    Title = model.Title,
                    Lyrics = model.Lyrics,
                    IsExplicit = model.IsExplicit,

                     CreatedUtc = DateTimeOffset.Now
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
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new SongListItem
                                {
                                    SongId = e.SongId,
                                    Title = e.Title,
                                    CreatedUtc = e.CreatedUtc
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
                        .Single(e => e.SongId == id && e.OwnerId == _userId);
                return
                    new SongDetail
                    {
                        SongId = entity.SongId,
                        Title = entity.Title,
                        Lyrics = entity.Lyrics,
                        IsExplicit = entity.IsExplicit,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
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
                        .Single(e => e.SongId == model.SongId && e.OwnerId == _userId);

                entity.Title = model.Title;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteSong(int songId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Songs
                        .Single(e => e.SongId == songId && e.OwnerId == _userId);

                ctx.Songs.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}