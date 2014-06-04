using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using LolFightProjekat.Models;

namespace LolFightProjekat.Controllers
{
    public class JungleAPIController : ApiController
    {
        private lolfighdatabaseEntities db = new lolfighdatabaseEntities();

        // GET api/JungleAPI
        public IQueryable<LogJungle> GetLogJungles()
        {
            return db.LogJungles;
        }

        // GET api/JungleAPI/5
        [ResponseType(typeof(LogJungle))]
        public async Task<IHttpActionResult> GetLogJungle(String username, int duration)
        {
            //Treba implementirati blokadu ako je duration+stariStarTime < NoviStarttime 


            //idChampion == idUser 1 na prema 1 veza
            var item = (from x in db.Users where x.Username == username select x.IdUser).First();
            int idChampion = (int)item;

            LogJungle logjungle = new LogJungle();

            System.Random r = new System.Random();
            int rInt = r.Next(0, 100); //for ints
            List<String> listOfReports = new List<String> { "u have been sucsessful", "you are good, well played", "jungle OP, GG WP" };
            int reportRandom = r.Next(0, listOfReports.Count);

            logjungle.Report = listOfReports[reportRandom];
            logjungle.Gold = rInt * duration;
            logjungle.StartTime = (int)DateTime.Now.Hour;
            logjungle.Duration = duration;
            logjungle.IdChampion = idChampion;

            db.LogJungles.Add(logjungle);
          

           
            await db.SaveChangesAsync();

           
            if (logjungle == null)
            {
                return NotFound();
            }

            return Ok(logjungle);
        }

        // PUT api/JungleAPI/5
        public async Task<IHttpActionResult> PutLogJungle(int id, LogJungle logjungle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != logjungle.IdLogJungle)
            {
                return BadRequest();
            }

            db.Entry(logjungle).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LogJungleExists(id))
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

        // POST api/JungleAPI
      //Obrisano nervira !!!! 405 error

        // DELETE api/JungleAPI/5
        [ResponseType(typeof(LogJungle))]
        public async Task<IHttpActionResult> DeleteLogJungle(int id)
        {
            LogJungle logjungle = await db.LogJungles.FindAsync(id);
            if (logjungle == null)
            {
                return NotFound();
            }

            db.LogJungles.Remove(logjungle);
            await db.SaveChangesAsync();

            return Ok(logjungle);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LogJungleExists(int id)
        {
            return db.LogJungles.Count(e => e.IdLogJungle == id) > 0;
        }
    }
}