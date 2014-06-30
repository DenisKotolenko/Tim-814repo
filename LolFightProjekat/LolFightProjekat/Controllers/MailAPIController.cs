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
    public class MailAPIController : ApiController
    {
        private lolfighdatabaseEntities db = new lolfighdatabaseEntities();




        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpGet]
        public IHttpActionResult SendMail(String username, String reciverName, String text, String title)
        {

            if ((db.Users.SingleOrDefault(user => user.Username == reciverName) == null))
                return Ok("Ne postoji korisnik, pokušajte ponovo!");
            else
            {
                var item = (from x in db.Users where x.Username == username select x.IdUser).First();
                int sender = (int)item;

                var item2 = (from x in db.Users where x.Username == reciverName select x.IdUser).First();
                int reciver = (int)item2;

                Mail m = new Mail();
                m.IdSender = sender;
                m.IdReceiver = reciver;
                m.Text = text;
                m.Time = DateTime.Now.Hour;
                m.Title = title;

                db.Mails.Add(m);
                db.SaveChanges();

                return Ok("Uspjesno poslana poruka!");
            }
        }

        public IQueryable GetMail(String username)
        {

            var item = (from x in db.Users where x.Username == username select x.IdUser).First();
            int idChampion = (int)item;
            //Ne ispisuje se ime sendera !!!
         

            return (from mail in db.Mails
                    join user in db.Users
                    on mail.IdReceiver equals user.IdUser
                    where mail.IdReceiver == idChampion
                    select new { mail.Title, user.Username, mail.Text, mail.Time, });

        }


        // PUT api/MailAPI/5
        public async Task<IHttpActionResult> PutMail(int id, Mail mail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mail.IdMail)
            {
                return BadRequest();
            }

            db.Entry(mail).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MailExists(id))
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

        // POST api/MailAPI
        [ResponseType(typeof(Mail))]
        public async Task<IHttpActionResult> PostMail(Mail mail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Mails.Add(mail);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = mail.IdMail }, mail);
        }

        // DELETE api/MailAPI/5
        [ResponseType(typeof(Mail))]
        public async Task<IHttpActionResult> DeleteMail(int id)
        {
            Mail mail = await db.Mails.FindAsync(id);
            if (mail == null)
            {
                return NotFound();
            }

            db.Mails.Remove(mail);
            await db.SaveChangesAsync();

            return Ok(mail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MailExists(int id)
        {
            return db.Mails.Count(e => e.IdMail == id) > 0;
        }
    }
}