using Music.Models.AlbumArtistFolder;
using Music.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace HappyMusic.WebAPI.Controllers
{
    public class AlbumArtistController : ApiController
    {
        /// <summary>
        /// Get a list of joiner tables that join artists and albums
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get()
        {
            AlbumArtistService albumArtistService = CreateAlbumArtistService();
            var albumArtists = albumArtistService.GetAlbumArtists();
            return Ok(albumArtists);
        }
        /// <summary>
        /// Creates a link between albumID and artistID
        /// </summary>
        /// <returns></returns>
        private AlbumArtistService CreateAlbumArtistService()
        {
            var albumArtistService = new AlbumArtistService();
            return albumArtistService;
        }
        /// <summary>
        /// Create a named list that connects artists to an Album
        /// </summary>
        /// <param name="albumArtist"></param>
        /// <returns></returns>
        public  IHttpActionResult Post(AlbumArtistCreate albumArtist)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateAlbumArtistService();

            if (!service.CreateAlbumArtist(albumArtist))
                return InternalServerError();
            return Ok();
        }
    }
}