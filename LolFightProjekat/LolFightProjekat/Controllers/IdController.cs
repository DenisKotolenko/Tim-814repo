using LolFightProjekat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LolFightProjekat.Controllers
{
    public class IdController : ApiController
    {
        private lolfighdatabaseEntities db = new lolfighdatabaseEntities();
        [AcceptVerbs("GET")]
        public IHttpActionResult Id(String username)
        {
            User u = db.Users.Where(a => a.Username.Equals(username)).First();
            return Ok(u.IdUser);
        } 
    }
}
