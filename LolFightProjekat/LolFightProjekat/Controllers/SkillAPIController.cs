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
    public class SkillAPIController : ApiController
    {
        private lolfighdatabaseEntities db = new lolfighdatabaseEntities();

        // GET api/SkillAPI
        public IQueryable<Skill> GetSkills()
        {
            return db.Skills;
        }

        // GET api/SkillAPI/5
        [ResponseType(typeof(Skill))]
        public async Task<IHttpActionResult> GetSkill(String username,String skillUp)
        {
            var id= (from x in db.Users where x.Username == username select x.IdUser).First();
            int idChampion = (int)id;
            Champion champ = db.Champions.Find(idChampion);
            Skill skill = db.Skills.Find(idChampion);
        
            if (skillUp == "attack")
            {
                champ.Gold = champ.Gold - 15;
                skill.AttackDamage = skill.AttackDamage + 1;
            }
            if (skillUp == "ability")
            {
                champ.Gold = champ.Gold - 25;
                skill.AbilityDamage = skill.AbilityDamage + 2;
            }
            if (skillUp == "attackSpeed")
            {
                champ.Gold = champ.Gold - 40;
                skill.AttackSpeed = skill.AttackSpeed + 50;
            }
            if (skillUp == "armor")
            {
                champ.Gold = champ.Gold - 20;
                skill.Armor = skill.Armor + 1;
            }

            if (skillUp == "magicResist")
            {
                champ.Gold = champ.Gold - 20;
                skill.MagicResist = skill.MagicResist + 1;
            }
            if (skillUp == "crit")
            {
                champ.Gold = champ.Gold - 25;
                skill.Critical = skill.Critical + 1;
            }
            if (skillUp == "armorpene")
            {
                champ.Gold = champ.Gold - 15;
                skill.ArmorPenetration = skill.ArmorPenetration + 1;
            }
            if (skillUp == "magicpene")
            {
                champ.Gold = champ.Gold - 10;
                skill.MagicPenetration = skill.MagicPenetration + 1;
            }
            if (skillUp == "hp")
            {
                champ.Gold = champ.Gold - 20;
                skill.HP = skill.HP + 25;
            }


            db.Entry(skill).State = EntityState.Modified;
            db.SaveChanges();

            if (skill == null)
            {
                return NotFound();
            }

           
            return Ok(skill);
        }

        // PUT api/SkillAPI/5
        public async Task<IHttpActionResult> PutSkill(int id, Skill skill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != skill.IdSkill)
            {
                return BadRequest();
            }

            db.Entry(skill).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SkillExists(id))
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

        // POST api/SkillAPI
        [ResponseType(typeof(Skill))]
        public async Task<IHttpActionResult> PostSkill(Skill skill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Skills.Add(skill);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SkillExists(skill.IdSkill))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = skill.IdSkill }, skill);
        }

        // DELETE api/SkillAPI/5
        [ResponseType(typeof(Skill))]
        public async Task<IHttpActionResult> DeleteSkill(int id)
        {
            Skill skill = await db.Skills.FindAsync(id);
            if (skill == null)
            {
                return NotFound();
            }

            db.Skills.Remove(skill);
            await db.SaveChangesAsync();

            return Ok(skill);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SkillExists(int id)
        {
            return db.Skills.Count(e => e.IdSkill == id) > 0;
        }
    }
}