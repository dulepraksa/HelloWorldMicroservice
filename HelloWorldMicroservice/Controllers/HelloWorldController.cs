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

            var retVal = Phrases.Store(p);

            if(retVal != null)
            {
                return Ok(retVal);
            }
            else
            {
                return BadRequest("Record could not be created");
            }
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(int id, PhraseDTO pdto)
        {
            Phrase p = new Phrase();

            p.Id = id;
            p.Body = pdto.Body;

            Phrase retVal = Phrases.Put(p);

            if(retVal != null)
            {
                return Ok(retVal);
            }
            else
            {
                return BadRequest("Record could not be updated");
            }
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