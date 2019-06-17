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
using System.Web.Mvc;
using HelloWorldMicroservice.DTO;

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
        public IHttpActionResult Post(PhraseDTO pdto)
        {
            Phrase p = new Phrase();
            p.Body = pdto.Body;

            bool retVal = Phrases.Store(p);
            if(retVal == true)
            {
                return Content(HttpStatusCode.Created, 201);
            }
            else
            {
                return Content(HttpStatusCode.InternalServerError,500);
            }
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            bool rows = Phrases.Delete(id);
            if(rows == true)
            {
                return Content(HttpStatusCode.NoContent, 204);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, 404);
            }


        }
    }
}