using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HappyMusic.WebAPI.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {
        // GET api/values
        /// <summary>
        /// will list out all values
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        /// <summary>
        /// get specific content
        /// </summary>
        /// <param name="id">Pass an ID</param>
        /// <returns></returns>
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        /// <summary>
        /// posts a string value
        /// </summary>
        /// <param name="value"></param>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        /// <summary>
        /// Edits specific content
        /// </summary>
        /// <param name="id">Pass an ID</param>
        /// <param name="value">Pass a value</param>
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        /// <summary>
        /// Deletes specific content
        /// </summary>
        /// <param name="id">Pass an ID</param>
        public void Delete(int id)
        {
        }
    }
}
