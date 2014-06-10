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
    public class BattlesController : ApiController
    {
        private lolfighdatabaseEntities db = new lolfighdatabaseEntities();

        // Returns ordered list of log battles of a champion chronologically.
        //[ResponseType(typeof(IQueryable<String>))]
        [AcceptVerbs("GET")]
        public IHttpActionResult Battles(int championId)
        {
            var Battles =
                    from LogBattle in db.LogBattles
                    where (LogBattle.IdAttacker == championId) || (LogBattle.IdDefender == championId)
                    orderby LogBattle.StartTime descending
                    select LogBattle.Report;
            return Ok(Battles);
        }
    }
}
