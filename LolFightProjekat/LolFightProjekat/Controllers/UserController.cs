using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LolFightProjekat.Models;

namespace LolFightProjekat.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(korisnici U)
        {
            if (ModelState.IsValid)
            {
                using (lolfightbazaEntities dc = new lolfightbazaEntities())
                {
                    dc.korisnicis.Add(U);
                    dc.SaveChanges();
                    ModelState.Clear();
                    U = null;
                    ViewBag.Message = "Registered succesfully!";
                }
            }
            return View(U);
        }
    }
}
