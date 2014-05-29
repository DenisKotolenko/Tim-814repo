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
using System.Web.Mvc;

namespace LolFightProjekat.Controllers
{
    public class ChampionTypeAPIController : ApiController
    {
        private lolfighdatabaseEntities db = new lolfighdatabaseEntities();

        // GET api/ChampionTypeAPI
        public IQueryable<ChampionType> GetChampionTypes()
        {
            return db.ChampionTypes;
        }




        // GET api/ChampionTypeAPI/5
        [ResponseType(typeof(ChampionType))]
        public IHttpActionResult GetChampionType(int id)
        {
            ChampionType championtype = db.ChampionTypes.Find(id);


            if (championtype == null)
            {
                return NotFound();
            }

            return Ok(championtype);
        }

        // PUT api/ChampionTypeAPI/5
        public IHttpActionResult PutChampionType(int id, ChampionType championtype)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != championtype.IdChampionType)
            {
                return BadRequest();
            }

            db.Entry(championtype).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChampionTypeExists(id))
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

        // POST api/ChampionTypeAPI
        [ResponseType(typeof(ChampionType))]
        public IHttpActionResult PostChampionType(ChampionType championtype)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ChampionTypes.Add(championtype);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = championtype.IdChampionType }, championtype);
        }

        // DELETE api/ChampionTypeAPI/5
        [ResponseType(typeof(ChampionType))]
        public IHttpActionResult DeleteChampionType(int id)
        {
            ChampionType championtype = db.ChampionTypes.Find(id);
            if (championtype == null)
            {
                return NotFound();
            }

            db.ChampionTypes.Remove(championtype);
            db.SaveChanges();

            return Ok(championtype);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ChampionTypeExists(int id)
        {
            return db.ChampionTypes.Count(e => e.IdChampionType == id) > 0;
        }
    }
}