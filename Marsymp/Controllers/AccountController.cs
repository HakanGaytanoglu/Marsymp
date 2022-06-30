using Marsymp.Models.ORM.Context;
using Marsymp.Models.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Marsymp.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(String Email_Address, String Password)
        {
            ProjectContext db = new ProjectContext();

            var user = db.Account.FirstOrDefault(x => x.Email_Address == Email_Address && x.Password == Password);

            var existRecord = db.Survey.FirstOrDefault(x => x.Email_Address == Email_Address);
         

            if (user == null)
            {
                ViewBag.Error = "Kullanıcı Bulunamadı";

                return View();
            }

            else
            {
                //create a cookie
                HttpCookie myCookie = new HttpCookie("myCookie");
                //Add key-values in the cookie
                myCookie.Values.Add("Name", user.Name);
                myCookie.Values.Add("Email", user.Email_Address);
                myCookie.Values.Add("ID", user.ID.ToString());
                //set cookie expiry date-time. Made it to last for next 12 hours.
                myCookie.Expires = DateTime.Now.AddHours(12);
                //Most important, write the cookie to client.
                Response.Cookies.Add(myCookie);

                if (existRecord == null)
                {
                return RedirectToAction("Index", "Survey");
                }
                else
                {
                    return RedirectToAction("Analysis", "Survey");
                }
            }
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Account account)
        {
            ProjectContext db = new ProjectContext();

           
                 db.Account.Add(account);
                 db.SaveChanges();               
                 return RedirectToAction("Login", "Account");
        

           
        }

    }
}