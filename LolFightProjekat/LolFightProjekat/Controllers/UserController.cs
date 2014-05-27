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
        private lolfighdatabaseEntities db = new lolfighdatabaseEntities();
        //
        // GET: /User/
        public ActionResult Index()
        {
         /*   int id = Int32.Parse(Session["LogedUserID"].ToString());
            User user = db.Users.Find(id);*/
            return View();
        }
        

        public ActionResult Logout(int id)
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("../../Home");
            return View();
        }
	}
}