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


        public IHttpActionResult Get()
        {
            PlaylistServices playlistService = CreatePlaylistService();
            var playlist = playlistService.GetPlayLists();
            return Ok(playlist);
        }
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
        public IHttpActionResult Get(int id)
        {
            PlaylistServices playlistService = CreatePlaylistService();
            var note = playlistService.GetPlaylistById(id);
            return Ok(note);
        }
        public IHttpActionResult Put(PlaylistEdit playlist)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePlaylistService();

            if (!service.UpdatePlaylist(playlist))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreatePlaylistService();

            if (!service.DeletePlaylist(id))
                return InternalServerError();

            return Ok();
        }
    }
}