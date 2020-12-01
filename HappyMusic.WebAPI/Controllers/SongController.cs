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
    public class SongController : ApiController
    {
        /// <summary>
        /// Gets a list of all songs
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get()
        {
            SongService songService = CreateSongService();
            var songs = songService.GetSongs();
            return Ok(songs);
        }

        private SongService CreateSongService()
        {
            
           // var userId = Guid.Parse(User.Identity.GetUserId());
            var songService = new SongService();
            return songService;
           
        }
        /// <summary>
        /// Create a song
        /// </summary>
        /// <param name="song">Pass a song name</param>
        /// <returns></returns>
        public IHttpActionResult Post(SongCreate song)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateSongService();

            if (!service.CreateSong(song))
                return InternalServerError();

            return Ok();
        }
        /// <summary>
        /// Get a song by ID
        /// </summary>
        /// <param name="id">Pass a song ID</param>
        /// <returns></returns>
        public IHttpActionResult Get(int id)
        {
            SongService songService = CreateSongService();
            var song = songService.GetSongById(id);
            return Ok(song);
        }
        /// <summary>
        /// Edit a song by ID
        /// </summary>
        /// <param name="song">Pass a song name</param>
        /// <returns></returns>
        public IHttpActionResult Put(SongEdit song)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateSongService();

            if (!service.UpdateSong(song))
                return InternalServerError();

            return Ok();
        }
        /// <summary>
        /// Delete a song by ID
        /// </summary>
        /// <param name="id">Pass a song ID</param>
        /// <returns></returns>
        public IHttpActionResult Delete(int id)
        {
            var service = CreateSongService();

            if (!service.DeleteSong(id))
                return InternalServerError();
            return Ok();
        }


    }
}
