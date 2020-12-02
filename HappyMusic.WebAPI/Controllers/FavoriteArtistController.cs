using Music.Models;
using Music.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HappyMusic.WebAPI.Controllers
{
    [Authorize]
    public class FavoriteArtistController : ApiController
    {
        /// <summary>
        /// Get all Favorite Artists
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get()
        {
            FavoriteArtistService favoriteArtistService = CreateFavoriteArtistService();
            var artist = favoriteArtistService.GetFavoriteArtists();
            return Ok(artist);
        }

      /// <summary>
      /// Create a Favorite Artist
      /// </summary>
      /// <param name="favoriteArtist">Pass a favoriteArtistName</param>
      /// <returns></returns>
        public IHttpActionResult Post(FavoriteArtistCreate favoriteArtist)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateFavoriteArtistService();

            if (!service.CreateFavoriteArtist(favoriteArtist))
                return InternalServerError();

            return Ok();
        }
        private FavoriteArtistService CreateFavoriteArtistService()
        {
           
            var Service = new FavoriteArtistService();
            return Service;
        }
       /// <summary>
       /// Get a favorite artist by ID
       /// </summary>
       /// <param name="id">Pass a favoriteArtistID</param>
       /// <returns></returns>
        public IHttpActionResult Get(int id)
        {
            FavoriteArtistService favoriteArtistService = CreateFavoriteArtistService();
            var service = favoriteArtistService.GetFavoriteArtistById(id);
            return Ok(service);
        }
      
      
    }
}

