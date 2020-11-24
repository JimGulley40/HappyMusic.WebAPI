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
        public IHttpActionResult Get()
        {
            AlbumArtistService albumArtistService = CreateAlbumArtistService();
            var albumArtists = albumArtistService.GetAlbumArtists();
            return Ok(albumArtists);
        }

        private AlbumArtistService CreateAlbumArtistService()
        {
            var albumArtistService = new AlbumArtistService();
            return albumArtistService;
        }

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