﻿using Microsoft.AspNet.Identity;
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
        public IHttpActionResult Get()
        {
            SongService songService = CreateSongService();
            var songs = songService.GetSongs();
            return Ok(songs);
        }

        private SongService CreateSongService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var songService = new SongService(userId);
            return songService;
        }
        public IHttpActionResult Post(SongCreate song)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateSongService();

            if (!service.CreateSong(song))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get(int id)
        {
            SongService songService = CreateSongService();
            var song = songService.GetSongById(id);
            return Ok(song);
        }
        public IHttpActionResult Put(SongEdit song)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateSongService();

            if (!service.UpdateSong(song))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateSongService();

            if (!service.DeleteSong(id))
                return InternalServerError();

            return Ok();
        }


    }
}