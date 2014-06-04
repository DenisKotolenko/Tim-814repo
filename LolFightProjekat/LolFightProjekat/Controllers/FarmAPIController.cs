using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using LolFightProjekat.Models;

namespace LolFightProjekat.Controllers
{
    public class FarmAPIController : ApiController
    {
        private lolfighdatabaseEntities db = new lolfighdatabaseEntities();

        // GET api/FarmAPI
        public IQueryable<LogFarm> GetLogFarms()
        {
            return db.LogFarms;
        }

        // GET api/FarmAPI/5
        [ResponseType(typeof(LogFarm))]
        public IHttpActionResult GetLogFarm(int id)
        {
            LogFarm logfarm = db.LogFarms.Find(id);
            if (logfarm == null)
            {
                return NotFound();
            }

            return Ok(logfarm);
        }

        // PUT api/FarmAPI/5
        public IHttpActionResult PutLogFarm(int id, LogFarm logfarm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != logfarm.IdLogFarm)
            {
                return BadRequest();
            }

            db.Entry(logfarm).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LogFarmExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/FarmAPI
        [ResponseType(typeof(LogFarm))]
        public IHttpActionResult PostLogFarm(LogFarm logfarm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LogFarms.Add(logfarm);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = logfarm.IdLogFarm }, logfarm);
        }

        // DELETE api/FarmAPI/5
        [ResponseType(typeof(LogFarm))]
        public IHttpActionResult DeleteLogFarm(int id)
        {
            LogFarm logfarm = db.LogFarms.Find(id);
            if (logfarm == null)
            {
                return NotFound();
            }

            db.LogFarms.Remove(logfarm);
            db.SaveChanges();

            return Ok(logfarm);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LogFarmExists(int id)
        {
            return db.LogFarms.Count(e => e.IdLogFarm == id) > 0;
        }
    }
}