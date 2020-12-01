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
    public class FavoriteArtistController : ApiController
    {
        public IHttpActionResult Get()
        {
            FavoriteArtistService favoriteArtistService = CreateFavoriteArtistService();
            var artist = favoriteArtistService.GetFavoriteArtists();
            return Ok(artist);
        }

      
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
       
        public IHttpActionResult Get(int id)
        {
            FavoriteArtistService favoriteArtistService = CreateFavoriteArtistService();
            var service = favoriteArtistService.GetFavoriteArtistById(id);
            return Ok(service);
        }
      
      
    }
}

