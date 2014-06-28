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
    public class ShopApiController : ApiController
    {
        private lolfighdatabaseEntities db = new lolfighdatabaseEntities();

        // GET api/ShopApi
        public IQueryable<Item> GetItems()
        {
            return db.Items;
        }

        // GET api/ShopApi/5
        [ResponseType(typeof(Item))]
        public async Task<IHttpActionResult> GetItem(int id)
        {
            Item item = await db.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }


        [System.Web.Http.AcceptVerbs("GET")]
        [System.Web.Http.HttpGet]
        // GET api/ShopApi/BuyItem?userid=id&itemid=idItem
        public async Task<IHttpActionResult> BuyItem(int userid, int IdItem)
        {


            Champion ch = db.Champions.Find(userid);
            Item it = db.Items.Find(IdItem);

            Inventory invent = new Inventory();

            invent.IdChampion=ch.IdChampion;
            invent.IdItem = it.IdItem;
            invent.Activated=0;

            db.Inventories.Add(invent);


            db.Entry(it).State = EntityState.Modified;


            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(it.IdItem))
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

        // POST api/ShopApi
        [ResponseType(typeof(Item))]
        public async Task<IHttpActionResult> PostItem(Item item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Items.Add(item);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = item.IdItem }, item);
        }

        // DELETE api/ShopApi/5
        [ResponseType(typeof(Item))]
        public async Task<IHttpActionResult> DeleteItem(int id)
        {
            Item item = await db.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            db.Items.Remove(item);
            await db.SaveChangesAsync();

            return Ok(item);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ItemExists(int id)
        {
            return db.Items.Count(e => e.IdItem == id) > 0;
        }
    }
}