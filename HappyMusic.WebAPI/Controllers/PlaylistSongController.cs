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

        public IHttpActionResult Get()
        {
            PlaylistSongServices playlistService = CreatePlaylistSongService();
            var playlist = playlistService.GetPlayListSongs();
            return Ok(playlist);
        }
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
            var userId = Guid.Parse(User.Identity.GetUserId());
            var noteService = new PlaylistSongServices(userId);
            return noteService;
        }
        public IHttpActionResult Get(int id)
        {
            PlaylistSongServices playlistService = CreatePlaylistSongService();
            var note = playlistService.GetPlaylistSongById(id);
            return Ok(note);
        }
       
        public IHttpActionResult Delete(int id)
        {
            var service = CreatePlaylistSongService();

            if (!service.DeletePlaylistSong(id))
                return InternalServerError();

            return Ok();
        }
    }
}

