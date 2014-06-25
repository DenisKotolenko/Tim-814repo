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
    public class ChampionAPIController : ApiController
    {
        private lolfighdatabaseEntities db = new lolfighdatabaseEntities();

        // GET api/ChampionAPI
        public IQueryable<Champion> GetChampions()
        {
            return db.Champions;
        }

          // GET api/ChampionAPI?username="neki string"
        [ResponseType(typeof(Champion))]
        public async Task<IHttpActionResult> GetEverything(String username)
        {
            //Treba implementirati blokadu ako je duration+stariStarTime < NoviStarttime 


            //idChampion == idUser 1 na prema 1 veza
            var item = (from x in db.Users where x.Username == username select x.IdUser).First();
            
            int idChampion = (int)item;

            Champion champion = new Champion();
            Skill skil = new Skill();
            ChampionType championType = new ChampionType();

            champion =  db.Champions.Find(idChampion);
             skil = db.Skills.Find(idChampion);
            championType = db.ChampionTypes.Find(champion.IdChampionType);


          //  var everything = champion +""+""+ skil+""+""+ championType;




            return Ok(champion);
        }

        // GET api/ChampionAPI/5
        [ResponseType(typeof(Champion))]
        public async Task<IHttpActionResult> GetChampion(int id)
        {
            Champion champion = await db.Champions.FindAsync(id);
            if (champion == null)
            {
                return NotFound();
            }

            return Ok(champion);
        }

        // PUT api/ChampionAPI/5
        public async Task<IHttpActionResult> PutChampion(int id, Champion champion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != champion.IdChampion)
            {
                return BadRequest();
            }

            db.Entry(champion).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChampionExists(id))
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

        // POST api/ChampionAPI
        [ResponseType(typeof(Champion))]
        public async Task<IHttpActionResult> PostChampion(Champion champion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Champions.Add(champion);
            Ranking rank = new Ranking();
            rank.Champion = champion;
            rank.FarmGold = 0;
            rank.StolenGold = 0;
            db.Rankings.Add(rank);


            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ChampionExists(champion.IdChampion))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = champion.IdChampion }, champion);
        }

        // DELETE api/ChampionAPI/5
        [ResponseType(typeof(Champion))]
        public async Task<IHttpActionResult> DeleteChampion(int id)
        {
            Champion champion = await db.Champions.FindAsync(id);
            if (champion == null)
            {
                return NotFound();
            }

            db.Champions.Remove(champion);
            await db.SaveChangesAsync();

            return Ok(champion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ChampionExists(int id)
        {
            return db.Champions.Count(e => e.IdChampion == id) > 0;
        }
    }
}