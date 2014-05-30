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

        // GET: /ChampionType/method/id
        public ActionResult method(int id)
        {

            Champion champion =
                 (from u in db.Champions
                  orderby u.IdChampion descending
                  select u).First();

            Champion champ = db.Champions.Find(champion.IdChampion);

            champ.IdChampionType = id;
            champ.Gold = 500;



            ChampionType skillchamp = db.ChampionTypes.Find(id);
            Skill skillnew = new Skill();
            skillnew.IdSkill = champ.IdChampion;
            skillnew.HP = skillchamp.HP;
            skillnew.AttackDamage = skillchamp.AttackDamage;
            skillnew.AbilityDamage = skillchamp.AbilityDamage;
            skillnew.Armor = skillchamp.Armor;
            skillnew.AttackSpeed = skillchamp.AttackSpeed;
            skillnew.MagicResist = skillchamp.MagicResist;
            skillnew.Critical = 1;
            skillnew.ArmorPenetration = 5;
            skillnew.MagicPenetration = 5;

            db.Skills.Add(skillnew);


            db.Entry(champ).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("../Login");


        }


        //change byte to picture
        public ActionResult PretvoriUSliku(int id)
        {


            ChampionType champTy = db.ChampionTypes.Find(id);
            Byte[] imageBytes = champTy.ImageURL.ToArray();

            FileContentResult f = File(imageBytes, "image/png");
            return f;
        }



        //Method about POST images
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {


            if (file != null && file.ContentLength > 0)
            {
                string targetFolder = System.Web.HttpContext.Current.Server.MapPath("~/");
                string targetPath = System.IO.Path.Combine(targetFolder, file.FileName);
                file.SaveAs(targetPath);

                int id = 0;

                ChampionType cht = (from ch in db.ChampionTypes
                                    orderby ch.IdChampionType descending
                                    select ch).First();


                id = cht.IdChampionType;

                ChampionType chTy = db.ChampionTypes.Find(id);

                byte[] image = new byte[file.ContentLength];
                file.InputStream.Read(image, 0, image.Length);

                chTy.ImageURL = image;



                db.SaveChanges();

            }
            return RedirectToAction("Index");
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
        public ActionResult Create([Bind(Include = "IdChampionType,Nation,Name,ImageLink,HP,AttackDamage,AbilityDamage,AttackSpeed,Armor,MagicResist,ImageURL")] ChampionType championtype)
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
        public ActionResult Edit([Bind(Include = "IdChampionType,Nation,Name,ImageLink,HP,AttackDamage,AbilityDamage,AttackSpeed,Armor,MagicResist,ImageURL")] ChampionType championtype)
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
