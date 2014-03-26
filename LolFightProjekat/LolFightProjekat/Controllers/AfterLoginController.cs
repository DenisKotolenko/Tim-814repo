using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LolFightProjekat.Controllers
{
    public class AfterLoginController : Controller
    {
        //
        // GET: /AfterLogin/

        public ActionResult AfterLogin()
        {
            
                if (Session["LogedUserID"] != null)
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("Index");
                }
            
        }

    }
}
