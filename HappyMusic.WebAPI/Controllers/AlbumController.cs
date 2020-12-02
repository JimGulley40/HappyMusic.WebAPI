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
    [Authorize]
    public class AlbumController : ApiController
    {
        /// <summary>
        /// Get all albums
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get()
        {
            AlbumService albumService = CreateAlbumService();
            var albums = albumService.GetAlbums();
            return Ok(albums);
        }
       
        private AlbumService CreateAlbumService()
        {
            //var userId = Guid.Parse(User.Identity.GetUserId());
            var albumService = new AlbumService(/*userId*/);
            return albumService;
        }
        /// <summary>
        /// Create an album
        /// </summary>
        /// <param name="album">Pass an album name</param>
        /// <returns></returns>
        public IHttpActionResult Post(AlbumCreate album)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAlbumService();

            if (!service.CreateAlbum(album))
                return InternalServerError();

            return Ok();
        }
        /// <summary>
        /// Get an album by ID
        /// </summary>
        /// <param name="id">Pass an album ID</param>
        /// <returns></returns>
        public IHttpActionResult Get(int id)
        {
            AlbumService albumService = CreateAlbumService();
            var album = albumService.GetAlbumById(id);
            return Ok(album);
        }
        /// <summary>
        /// Edit an album by ID
        /// </summary>
        /// <param name="album">Pass an ID</param>
        /// <returns></returns>
        public IHttpActionResult Put(AlbumEdit album)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAlbumService();

            if (!service.UpdateAlbum(album))
                return InternalServerError();

            return Ok();
        }
        /// <summary>
        /// Delete an album by ID
        /// </summary>
        /// <param name="id">Pass an album ID</param>
        /// <returns></returns>
        public IHttpActionResult Delete(int id)
        {
            var service = CreateAlbumService();

            if (!service.DeleteAlbum(id))
                return InternalServerError();

            return Ok();
        }


    }
}