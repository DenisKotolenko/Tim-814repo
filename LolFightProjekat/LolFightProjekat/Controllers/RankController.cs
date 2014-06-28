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
    public class RankController : ApiController
    {
        private lolfighdatabaseEntities db = new lolfighdatabaseEntities();
       

        // Returns ordered list of Champion ids by farmed gold amount.
        //[ResponseType(typeof(IQueryable<String>))]
        [AcceptVerbs("GET")]
        public IHttpActionResult RankFarm()
        {

            var Ranks =
                    from Ranking in db.Rankings
                    orderby Ranking.FarmGold descending
                    //select Ranking.Champion;
                    select new { Ranking.Champion.IdChampion, Ranking.Champion.User.Username, Ranking.Champion.Ranking.FarmGold };
            return Ok(Ranks);
        }

        //Returns ordered list of Champion ids by stolen gold amount.
        /*[ResponseType(typeof(List<Champion>))]
        [AcceptVerbs("GET")]
        public IHttpActionResult RankSteal()
        {
            var Ranks =
                    from Ranking in db.Rankings
                    orderby Ranking.StolenGold descending
                    select Ranking.Champion;
            return Ok(Ranks.ToList());
        }*/
    }
}
