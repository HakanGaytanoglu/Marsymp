using Marsymp.Models.ORM.Context;
using Marsymp.Models.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Marsymp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Account account)
        {
            ProjectContext db = new ProjectContext();
            db.Account.Add(account);
            db.SaveChanges();
          
            return View();
            
        }

        public ActionResult Services()
        {
            return View();
        }

        public ActionResult Instruments()
        {
            return View();
        }
    }
}
