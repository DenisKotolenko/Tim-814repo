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
using Random.Org;

namespace LolFightProjekat.Controllers
{
    public class FightController : ApiController
    {
        private lolfighdatabaseEntities db = new lolfighdatabaseEntities();
        static Random.Org.Random rnd = new Random.Org.Random();

        // Returns random champion id from a list of champions who are not the
        // current user nor banned. Using random.org randomizer.
        [AcceptVerbs("GET")]
        //[ResponseType(typeof(IHttpActionResult))]
        public IHttpActionResult RandomEnemy(int championId)
        {
            var Actives =
                    from Champion in db.Champions
                    where Champion.BanCooldown == 0 && Champion.IdChampion != championId
                    select Champion.IdChampion;
            List<Int32> Actives2 = Actives.ToList();
            //int rank = rnd.Next(0, Actives2.Count());
            int rank = 0;
            return Fight(championId, Actives2[rank]);
        }

        [AcceptVerbs("PUT", "GET")]
        //[ResponseType(typeof(String))]
        public IHttpActionResult Fight(int attackId, int defendId)
        {
            Champion Attacker = db.Champions.Find(attackId);
            Champion Defender = db.Champions.Find(defendId);
            LogBattle Fajt = new LogBattle();
            Fajt.IdAttacker = attackId;
            Fajt.IdDefender = defendId;
            Fajt.StartTime = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            Int32 IdLoser;
            //if (Attacker.Skill.AttackDamage > Defender.Skill.Armor)
            if (true)
            {
                Fajt.IdWinner = attackId;
                IdLoser = defendId;
            }
            else
            {
                Fajt.IdWinner = defendId;
                IdLoser = attackId;
            }
            Champion Winner = db.Champions.Find(Fajt.IdWinner);
            Champion Loser = db.Champions.Find(IdLoser);
            Fajt.Gold = (Int32)(Loser.Gold * 0.05);
            Fajt.Report = Attacker.User.Username + " attacked " + Defender.User.Username + "! " + Winner.User.Username + " won " + Fajt.Gold + " $!";
            Loser.Gold -= Fajt.Gold;
            Winner.Gold += Fajt.Gold;
            db.LogBattles.Add(Fajt);
            db.SaveChanges();
            return Ok(Fajt.Report);
        }
    }
}
