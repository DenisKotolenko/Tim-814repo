using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LolFightProjekat.Models;

namespace LolFightProjekat.Controllers
{
    public class ChampionTypeController : Controller
    {
        private lolfighdatabaseEntities db = new lolfighdatabaseEntities();

        // GET: /ChampionType/
        public ActionResult Index()
        {
            return View(db.ChampionTypes.ToList());
        }

        // GET: /ChampionType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChampionType championtype = db.ChampionTypes.Find(id);
            if (championtype == null)
            {
                return HttpNotFound();
            }
            return View(championtype);
        }

        // GET: /ChampionType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /ChampionType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="IdChampionType,Nation,Name,ImageLink,HP,AttackDamage,AbilityDamage,AttackSpeed,Armor,MagicResist,ImageURL")] ChampionType championtype)
        {
            if (ModelState.IsValid)
            {
                db.ChampionTypes.Add(championtype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(championtype);
        }

        // GET: /ChampionType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChampionType championtype = db.ChampionTypes.Find(id);
            if (championtype == null)
            {
                return HttpNotFound();
            }
            return View(championtype);
        }

        // POST: /ChampionType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="IdChampionType,Nation,Name,ImageLink,HP,AttackDamage,AbilityDamage,AttackSpeed,Armor,MagicResist,ImageURL")] ChampionType championtype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(championtype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(championtype);
        }

        // GET: /ChampionType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChampionType championtype = db.ChampionTypes.Find(id);
            if (championtype == null)
            {
                return HttpNotFound();
            }
            return View(championtype);
        }

        // POST: /ChampionType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChampionType championtype = db.ChampionTypes.Find(id);
            db.ChampionTypes.Remove(championtype);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
