using Music.Data;
using Music.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Services
{
    //this is a service class for the joining table of FavoriteArtist. 
    //This service class joins Artists to the profile based off of if they are listed as 
    //a favorite of the profile , 
    public class FavoriteArtistService
    {

        //This is the Create method of crud. it takes these parameters listed below
        public bool CreateFavoriteArtist(FavoriteArtistCreate model)
        {
            var entity =
                new FavoriteArtist()
                {
                   ProfileId=model.ProfileId,
                   ArtistId = model.ArtistId,
                    FavoriteArtistId=model.FavoriteArtistId,
                    ArtistName=model.ArtistName
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.FavoriteArtist.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //Read/List method of FavoriteArtists-- This is integral when you are listing in the profile a list of favorite artists-- it takes 
        //the artists Id from the artists table and the name and lists them out 
        public IEnumerable<FavoriteArtistListItem> GetFavoriteArtists()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Artists
                        

                        .Select(
                            e =>
                                new FavoriteArtistListItem
                                {
                                  
                                   ArtistId = e.ArtistId,
                                   
                                   ArtistName = e.ArtistName
                                    
                                }
                        );

                return query.ToArray();
            }
        }

        //Read method by ID, uses the same method as earlier, but is an overload taking an ID number and 
        // pulling it in to show a favorite artist
        public FavoriteArtistDetail GetFavoriteArtistById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .FavoriteArtist
                        .Single(e => e.FavoriteArtistId == id);
                return
                    new FavoriteArtistDetail
                    {
                       FavoriteArtistId=entity.FavoriteArtistId,
                       ProfileId = entity.ProfileId,
                       ArtistId = entity.ArtistId

                    };
            }

        }
    }
}
