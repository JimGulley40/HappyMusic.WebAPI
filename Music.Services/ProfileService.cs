using Music.Data;
using Music.Models;
using Music.Models.ProfileFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Services
{
    public class ProfileService
    {
        public bool CreateProfile(ProfileCreate model)
        {
            var entity =
                new Profile()
                {

                    ProfileId = model.ProfileId,
                    UserName = model.UserName,
                    StartDate = model.StartDate,
                   
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Profile.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ProfileListItems> GetProfiles()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Profile

                        .Select(
                            e =>
                                new ProfileListItems
                                {
                                    ProfileId = e.ProfileId,
                                    UserName = e.UserName,
                                    StartDate = e.StartDate,
                                    Songs = e.Songs.Select(
                                        b =>
                                            new SongDetail
                                            {
                                                SongId = b.SongId,
                                                Title = b.Title,
                                                IsExplicit = b.IsExplicit,
                                                Lyrics = b.Lyrics,
                                                AlbumName = b.Album.Title
                                            }).ToList()

                                    //PlaylistName =e.PlaylistId
                                }
                        );

                return query.ToArray();
            }
        }
        public ProfileDetail GetProfileById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Profile
                        .Single(e => e.ProfileId == id);
                return
                    new ProfileDetail
                    {
                        ProfileId = entity.ProfileId,
                        UserName = entity.UserName,
                        StartDate = entity.StartDate
                       

                    };
            }

        }
        public bool UpdateProfile(ProfileEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Profile
                        .Single(e => e.ProfileId == model.ProfileId);

                           entity.UserName = model.UserName;
                           
               

                return ctx.SaveChanges() == 1;
            }
        }
        
        public bool DeleteProfile(int profileId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Profile
                        .Single(e => e.ProfileId == profileId);

                ctx.Profile.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
