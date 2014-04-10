using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using LolFightProjekat.Models;

namespace LolFightProjekat.Controllers
{
    public class LoginController : BaseController
    {
        //
        // GET: /Login/

      public ActionResult Index()
    {
        return View();
    }

      [HttpPost]
      [ValidateAntiForgeryToken]
      public ActionResult Index(Admin u)
      {
          // this action is for handle post (login)
          if (ModelState.IsValid) // this is check validity
          {
              using (lolfighdatabaseEntities dc = new lolfighdatabaseEntities())
              {
                  var v = dc.Admins.Where(a => a.Username.Equals(u.Username) && a.Password.Equals(u.Password)).FirstOrDefault();
                  if (v != null)
                  {
                      Session["LogedUserID"] = v.IdAdmin.ToString();
                      Session["LogedUserFullname"] = v.Username.ToString();
                      return RedirectToAction("../Admin");
                  }
              }
          }
          return View(u);
      }
}
}
