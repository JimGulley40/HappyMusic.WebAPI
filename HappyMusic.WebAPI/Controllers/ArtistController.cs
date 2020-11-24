using Microsoft.AspNet.Identity;
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
    
    public class ArtistController : ApiController
    {
        /// <summary>
        /// Get all artists
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get()
        {
            ArtistService artistService = CreateArtistService();
            var artists = artistService.GetArtists();
            return Ok(artists);
        }

        private ArtistService CreateArtistService()
        {
            //var userId = Guid.Parse(User.Identity.GetUserId());
            var artistService = new ArtistService(/*userId*/);
            return artistService;
        }
        /// <summary>
        /// Create an artist
        /// </summary>
        /// <param name="artist">Pass the name of the artist</param>
        /// <returns></returns>
        public IHttpActionResult Post(ArtistCreate artist)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateArtistService();

            if (!service.CreateArtist(artist))
                return InternalServerError();

            return Ok();
        }
        /// <summary>
        /// Get an artist by ID
        /// </summary>
        /// <param name="id">Pass the artistID</param>
        /// <returns></returns>
        public IHttpActionResult Get(int id)
        {
            ArtistService artistService = CreateArtistService();
            var artist = artistService.GetArtistById(id);
            return Ok(artist);
        }

        /// <summary>
        /// Edit an artist by ID
        /// </summary>
        /// <param name="artist"></param>
        /// <returns></returns>
        public IHttpActionResult Put(ArtistEdit artist)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateArtistService();

            if (!service.UpdateArtist(artist))
                return InternalServerError();

            return Ok();
        }

        /// <summary>
        /// Delete an artist by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult Delete(int id)
        {
            var service = CreateArtistService();

            if (!service.DeleteArtist(id))
                return InternalServerError();

            return Ok();
        }


    }
}