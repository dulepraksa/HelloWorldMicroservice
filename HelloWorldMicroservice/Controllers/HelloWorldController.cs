using HelloWorldMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using HelloWorldMicroservice.Store;

namespace HelloWorldMicroservice.Controllers
{
    public class HelloWorldController : ApiController
    {
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            var phrases = Phrases.Get();
            return Ok(phrases);
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            var phrase = Phrases.Get(id);
            return Ok(phrase);
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {

        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}