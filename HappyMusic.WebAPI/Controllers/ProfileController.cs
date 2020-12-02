using Microsoft.AspNet.Identity;
using Music.Models.ProfileFolder;
using Music.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HappyMusic.WebAPI.Controllers
{
    public class ProfileController : ApiController
    {
        /// <summary>
        /// Get all Profiles
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get()
        {
            ProfileService profileService = CreateProfileService();
            var profile = profileService.GetProfiles();
            return Ok(profile);
        }

        private ProfileService CreateProfileService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var profileService = new ProfileService(userId);
            return profileService;
        }
        /// <summary>
        /// Create A Profile
        /// </summary>
        /// <param name="profile">Pass a Name for the profile</param>
        /// <returns></returns>
        public IHttpActionResult Post(ProfileCreate profile)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateProfileService();

            if (!service.CreateProfile(profile))
                return InternalServerError();

            return Ok();
        }
        /// <summary>
        /// Get a profile by ID
        /// </summary>
        /// <param name="id">Pass a profileID</param>
        /// <returns></returns>
        public IHttpActionResult Get(int id)
        {
            ProfileService profileService = CreateProfileService();
            var profile = profileService.GetProfileById(id);
            return Ok(profile);
        }
        /// <summary>
        /// Edit a profile by ID
        /// </summary>
        /// <param name="profile">Pass a profile name</param>
        /// <returns></returns>
        public IHttpActionResult Put(ProfileEdit profile)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateProfileService();

            if (!service.UpdateProfile(profile))
                return InternalServerError();

            return Ok();
        }
        /// <summary>
        /// Delete profile by ID
        /// </summary>
        /// <param name="id">Pass a profileID</param>
        /// <returns></returns>
        public IHttpActionResult Delete(int id)
        {
            var service = CreateProfileService();

            if (!service.DeleteProfile(id))
                return InternalServerError();

            return Ok();
        }
    }
}
