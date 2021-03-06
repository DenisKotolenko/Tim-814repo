﻿using System;
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
                    from log in db.LogBattles
                    where (log.IdAttacker == championId) || (log.IdDefender == championId)
                    orderby log.StartTime descending
                    select new { log.StartTime, log.Report};
            return Ok(Battles);
        }
    }
}
