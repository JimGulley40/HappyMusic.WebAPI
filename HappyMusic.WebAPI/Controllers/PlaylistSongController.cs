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
    public class PlaylistSongController : ApiController
    {
        /// <summary>
        /// Get a list of all playlists and songs
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get()
        {
            PlaylistSongServices playlistService = CreatePlaylistSongService();
            var playlist = playlistService.GetPlayListSongs();
            return Ok(playlist);
        }

        /// <summary>
        /// Assign a song to a playlist
        /// </summary>
        /// <param name="playlist">Pass playlistsong ID</param>
        /// <returns></returns>
        public IHttpActionResult Post(PlaylistSongCreate playlist)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePlaylistSongService();

            if (!service.CreatePlaylistSong(playlist))
                return InternalServerError();

            return Ok();
        }
        private PlaylistSongServices CreatePlaylistSongService()
        {
            //var userId = Guid.Parse(User.Identity.GetUserId());
            var noteService = new PlaylistSongServices();
            return noteService;
        }
        /// <summary>
        /// Get playlistsong by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult Get(int id)
        {
            PlaylistSongServices playlistService = CreatePlaylistSongService();
            var note = playlistService.GetPlaylistSongById(id);
            return Ok(note);
        }
       /// <summary>
       /// Delete Playlist song by ID
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
        public IHttpActionResult Delete(int id)
        {
            var service = CreatePlaylistSongService();

            if (!service.DeletePlaylistSong(id))
                return InternalServerError();

            return Ok();
        }
    }
}

