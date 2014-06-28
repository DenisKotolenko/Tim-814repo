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
    public class AdminController : BaseController
    {
        private lolfighdatabaseEntities db = new lolfighdatabaseEntities();




        //Method who worries about uploading images
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                string targetFolder = System.Web.HttpContext.Current.Server.MapPath("~/");
                string targetPath = System.IO.Path.Combine(targetFolder, file.FileName);
                file.SaveAs(targetPath);


                int id = 0;
                if (Session["LogedUserID"] != null)
                    id = Int32.Parse(Session["LogedUserID"].ToString());

                Admin admin = db.Admins.Find(id);

                byte[] image = new byte[file.ContentLength];
                file.InputStream.Read(image, 0, image.Length);

                admin.ImageURL = image;


                //      db.Admins.Add(admin);
                db.SaveChanges();

            }
            return RedirectToAction("Index");
        }

        //Method for turning byte into picture
        public ActionResult PretvoriUSliku(int id)
        {

            Admin admin = db.Admins.Find(id);
            Byte[] imageBytes = admin.ImageURL.ToArray();

            FileContentResult f = File(imageBytes, "image/jpeg");
            return f;

        }
        //Logout
        public ActionResult Logout(int id)
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("../../Home");
            return View();
        }



        //
        // GET: /Admin/

        public ActionResult Index()
        {

         int id = Int32.Parse(Session["LogedUserID"].ToString());
         Admin admin = db.Admins.Find(id);
         return View(admin);

        }

        //
        // GET: /Admin/AddAdmin

        public ActionResult AddAdmin()
        {
            return View(db.Admins.ToList());
        }

        //
        // GET: /Admin/Details/5

        public ActionResult Details(int id = 0)
        {
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        //
        // GET: /Admin/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Admin admin)
        {
            if (ModelState.IsValid)
            {
                db.Admins.Add(admin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(admin);
        }

        //
        // GET: /Admin/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        //
        // POST: /Admin/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Admin admin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(admin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(admin);
        }

        //
        // GET: /Admin/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        //
        // POST: /Admin/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Admin admin = db.Admins.Find(id);
            db.Admins.Remove(admin);
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