using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using LolFightProjekat.Models;

namespace LolFightProjekat.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

      public ActionResult Login()
    {
        return View();
    }

      [HttpPost]
      [ValidateAntiForgeryToken]
      public ActionResult Login(User u)
      {
          // this action is for handle post (login)
          if (ModelState.IsValid) // this is check validity
          {
              using (LolDbContext dc = new LolDbContext())
              {
                  var v = dc.Users.Where(a => a.Username.Equals(u.Username) && a.Password.Equals(u.Password)).FirstOrDefault();
                  if (v != null)
                  {
                      Session["LogedUserID"] = v.IdUser.ToString();
                      Session["LogedUserFullname"] = v.Username.ToString();
                      return RedirectToAction("../AfterLogin/AfterLogin");
                  }
              }
          }
          return View(u);
      }
}
}
