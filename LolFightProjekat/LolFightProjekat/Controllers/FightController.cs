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
        [ResponseType(typeof(Champion))]
        public IHttpActionResult RandomEnemy(int championId)
        {
            var Actives =
                    from Champion in db.Champions
                    where Champion.BanCooldown == 0 && Champion.IdChampion != championId
                    select Champion;
            List<Champion> Actives2 = Actives.ToList();
            //int rank = rnd.Next(0, Actives2.Count());
            int rank = 0;
            return Ok(Actives2[rank]);
        }
    }
}
