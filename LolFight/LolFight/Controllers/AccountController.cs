using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using System.Net.Mail;
using Microsoft.AspNet.Identity.EntityFramework;
using Recaptcha;
using WebMatrix.WebData;
using LolFight.Filters;

namespace LolFight.Controllers
{
    public class AccountController : BaseController
    {
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [InitializeSimpleMembership]
        [RecaptchaControlMvc.CaptchaValidatorAttribute] 
        [ValidateAntiForgeryToken]
        public ActionResult Register(User U)
        {
            /*if (!captchaValid)
            {
                ModelState.AddModelError("", "You did not type the verification word correctly. Please try again.");
            }
            else
            {
             */ 
            if (ModelState.IsValid)
            {
                using (LolContext dc = new LolContext())
                {
                    //Create membership for email reg.
                    MembershipCreateStatus CS = new MembershipCreateStatus();
                    Membership.CreateUser(U.Username, U.Password, U.eMail, null, null, false, null, out CS);
                    FormsAuthentication.SetAuthCookie(U.Username, false);
                    
                    // Creating user and corresponding empty champion.
                    dc.Users.Add(U);
                    Champion C = new Champion();
                    C.IdChampion = U.IdUser;
                    C.IdChampionType = 1;
                    C.BanCooldown = -1;
                    dc.Champions.Add(C);

                    // Sending email for validation through lolfight814@gmail.com
                    MailMessage msg = new MailMessage();
                    System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
                    msg.Subject = Resources.Resources.EmailSubject;
                    var user = Membership.GetUser(U.Username.ToString());
                    var Token = user.ProviderUserKey.ToString();
                    msg.Body = string.Format(Resources.Resources.EmailBody, U.Username, Url.Action("Confirm", "Account", new {Token}, Request.Url.Scheme));
                    msg.From = new MailAddress("lolfight814@gmail.com");
                    msg.To.Add(U.eMail);
                    msg.IsBodyHtml = true;
                    client.Host = "smtp.gmail.com";
                    System.Net.NetworkCredential basicauthenticationinfo = new System.Net.NetworkCredential("lolfight814@gmail.com", "814lolfight");
                    client.Port = int.Parse("587");
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;
                    client.Credentials = basicauthenticationinfo;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.Send(msg);

                    //Save changes, clear and return an inspiring message.
                    dc.SaveChanges();
                    ModelState.Clear();
                    U = null;
                    C = null;
                    ViewBag.Message = Resources.Resources.RegisterOK;
                }

            }
            return View(U);
            }

        public ActionResult Confirm(int? Token)
        {
            if (string.IsNullOrEmpty(Token.ToString()))
            {
                ViewBag.Msg = Resources.Resources.BadToken;
                return View();
            }
            else
            {
                var user = Membership.GetUser(new Guid(Token.ToString()));
                if (!user.IsApproved)
                {
                    user.IsApproved = true;
                    Membership.UpdateUser(user);
                    FormsAuthentication.SetAuthCookie(user.UserName, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    FormsAuthentication.SignOut();
                    ViewBag.Msg = Resources.Resources.EmailAlready;
                    return RedirectToAction("LogOn");
                }
            }
        }
    }
}
//}
