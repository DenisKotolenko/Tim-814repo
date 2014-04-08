using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LolFightProjekat.Models;

namespace LolFightProjekat.Controllers
{
    public class AddingItemsController : Controller
    {
        private lolfightbazaEntities db = new lolfightbazaEntities();

        //
        // GET: /AddingItems/

        public ActionResult Index()
        {
            return View(db.sviitemis.ToList());
        }

        //
        // GET: /AddingItems/Details/5

        public ActionResult Details(int id = 0)
        {
            sviitemi sviitemi = db.sviitemis.Find(id);
            if (sviitemi == null)
            {
                return HttpNotFound();
            }
            return View(sviitemi);
        }

        //
        // GET: /AddingItems/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /AddingItems/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(sviitemi sviitemi)
        {
            if (ModelState.IsValid)
            {
                db.sviitemis.Add(sviitemi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sviitemi);
        }

        //
        // GET: /AddingItems/Edit/5

        public ActionResult Edit(int id = 0)
        {
            sviitemi sviitemi = db.sviitemis.Find(id);
            if (sviitemi == null)
            {
                return HttpNotFound();
            }
            return View(sviitemi);
        }

        //
        // POST: /AddingItems/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(sviitemi sviitemi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sviitemi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sviitemi);
        }

        //
        // GET: /AddingItems/Delete/5

        public ActionResult Delete(int id = 0)
        {
            sviitemi sviitemi = db.sviitemis.Find(id);
            if (sviitemi == null)
            {
                return HttpNotFound();
            }
            return View(sviitemi);
        }

        //
        // POST: /AddingItems/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            sviitemi sviitemi = db.sviitemis.Find(id);
            db.sviitemis.Remove(sviitemi);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}