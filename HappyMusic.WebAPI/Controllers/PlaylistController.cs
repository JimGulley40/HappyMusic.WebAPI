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

    public class PlaylistController : ApiController
    {

        /// <summary>
        /// Get a list of playlists
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get()
        {
            PlaylistServices playlistService = CreatePlaylistService();
            var playlist = playlistService.GetPlayLists();
            return Ok(playlist);
        }
        /// <summary>
        /// Create a Playlist
        /// </summary>
        /// <param name="playlist">Pass a name for the Playlist</param>
        /// <returns></returns>
        public IHttpActionResult Post(PlaylistCreate playlist)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePlaylistService();

            if (!service.CreatePlaylist(playlist))
                return InternalServerError();

            return Ok();
        }
        private PlaylistServices CreatePlaylistService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var noteService = new PlaylistServices(userId);
            return noteService;
        }
        /// <summary>
        /// Get playlist by ID
        /// </summary>
        /// <param name="id">Pass a playlist ID</param>
        /// <returns></returns>
        public IHttpActionResult Get(int id)
        {
            PlaylistServices playlistService = CreatePlaylistService();
            var note = playlistService.GetPlaylistById(id);
            return Ok(note);
        }
        /// <summary>
        /// Update a playlist by ID
        /// </summary>
        /// <param name="playlist">pass an updated name for the playlist</param>
        /// <returns></returns>
        public IHttpActionResult Put(PlaylistEdit playlist)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePlaylistService();

            if (!service.UpdatePlaylist(playlist))
                return InternalServerError();

            return Ok();
        }
        /// <summary>
        /// Delete a playlist by Id
        /// </summary>
        /// <param name="id">Pass an ID for the playlist</param>
        /// <returns></returns>
        public IHttpActionResult Delete(int id)
        {
            var service = CreatePlaylistService();

            if (!service.DeletePlaylist(id))
                return InternalServerError();

            return Ok();
        }
    }

}

