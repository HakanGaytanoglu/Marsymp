using Marsymp.Models.ORM.Context;
using Marsymp.Models.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Marsymp.Controllers
{
    public class SurveyController : Controller
    {
        // GET: Survey

        public ActionResult Index()
        {


            HttpCookie myCookie = Request.Cookies["myCookie"];

            if (myCookie == null)
            {
                return new HttpUnauthorizedResult();
            }


            if (!string.IsNullOrEmpty(myCookie.Values["Name"]))

            {

                string Name = myCookie.Values["Name"];
                string Email = myCookie.Values["Email"];
                string ID = myCookie.Values["ID"];
                //Yes userId is found. Mission accomplished.

                ViewBag.User = Name;
                ViewBag.Email = Email;
                ViewBag.ID = ID;

            }

            var date = System.DateTime.Now;

            ViewBag.date = date;

            if (TempData["Error"] != null)
            {
                ViewBag.Message = "Please set your company goals and their priorities correctly!";
                TempData.Remove("Error");
            }



            return View();


        }

        [HttpPost]
        public ActionResult Index(Survey Survey)
        {


            ProjectContext db = new ProjectContext();
            db.Survey.Add(Survey);
            db.SaveChanges();

            return RedirectToAction("Analysis", "Survey");



        }


        public ActionResult Analysis()
        {
            HttpCookie myCookie = Request.Cookies["myCookie"];

            if (myCookie == null)
            {
                return new HttpUnauthorizedResult();
            }


            if (!string.IsNullOrEmpty(myCookie.Values["Name"]))

            {

                string Name = myCookie.Values["Name"];
                string Email = myCookie.Values["Email"];
                string ID = myCookie.Values["ID"];
                //Yes userId is found. Mission accomplished.

                ViewBag.User = Name;
                ViewBag.Email = Email;
                ViewBag.ID = ID;


                //Passing model to view
                ProjectContext db = new ProjectContext();

                var user = db.Survey.Where(x => x.Email_Address == Email).OrderByDescending(x => x.Start_Date).First();

                if (user.Brand_Awareness != null || user.Sales_Generation != null || user.Traffic_Generation != null || user.Lead_Generation != null && user.Brand_Awareness_Priority == "1" || user.Traffic_Generation_Priority == "1" || user.Lead_Generation_Priority == "1" || user.Sales_Generation_Priority == "1")
                {



                    // Budget calculation for Brand Awareness
                    if (user.Brand_Awareness != null && Convert.ToInt32(user.Brand_Awareness_Priority) == 1)
                    {
                        ViewBag.Brand_Awareness = "Content Marketing, Social Media Marketing, Display Advertising,";



                        if (user.Brand_Awareness != null && user.Lead_Generation != null)
                        {
                            ViewBag.Brand_Awareness = "Content Marketing, Social Media Marketing";
                        }


                        double bap = (Convert.ToInt32(user.Brand_Awareness_Priority)) + (Convert.ToInt32(user.Lead_Generation_Priority)) + (Convert.ToInt32(user.Sales_Generation_Priority)) + (Convert.ToInt32(user.Traffic_Generation_Priority));

                        switch (bap)
                        {
                            case 1:
                                double result1 = user.Budget1 / 1;
                                ViewBag.case1 = result1.ToString("0.00") + " " + user.Currency;
                                break;
                            case 3:
                                double result31 = user.Budget1 / 1.6;
                                ViewBag.case31 = result31.ToString("0.00") + " " + user.Currency;
                                break;
                            case 6:
                                double result61 = user.Budget1 / 2.2;
                                ViewBag.case61 = result61.ToString("0.00") + " " + user.Currency;
                                break;
                            case 10:
                                double result10 = user.Budget1 / 2.5;
                                ViewBag.case11 = result10.ToString("0.00") + " " + user.Currency;
                                break;
                            default:
                                ViewBag.BA_P1 = "Please check your inputs";
                                break;
                        }
                    }

                    if (user.Brand_Awareness != null && Convert.ToInt32(user.Brand_Awareness_Priority) == 2)
                    {
                        ViewBag.Brand_Awareness = "Content Marketing, Social Media Marketing, Display Advertising,";

                        if (user.Brand_Awareness != null && user.Lead_Generation != null)
                        {
                            ViewBag.Brand_Awareness = "Content Marketing, Social Media Marketing";
                        }


                        double bap = (Convert.ToInt32(user.Brand_Awareness_Priority)) + (Convert.ToInt32(user.Lead_Generation_Priority)) + (Convert.ToInt32(user.Sales_Generation_Priority)) + (Convert.ToInt32(user.Traffic_Generation_Priority));

                        switch (bap)
                        {

                            case 3:
                                double result32 = user.Budget1 / 2.666;
                                ViewBag.case32 = result32.ToString("0.00") + " " + user.Currency;
                                break;
                            case 6:
                                double result62 = user.Budget1 / 2.85;
                                ViewBag.case62 = result62.ToString("0.00") + " " + user.Currency;
                                break;
                            case 10:
                                double result12 = user.Budget1 / 3.33333;
                                ViewBag.case12 = result12.ToString("0.00") + " " + user.Currency;
                                break;
                            default:
                                ViewBag.BA_P1 = "Please check your inputs";
                                break;
                        }
                    }

                    if (user.Brand_Awareness != null && Convert.ToInt32(user.Brand_Awareness_Priority) == 3)
                    {
                        ViewBag.Brand_Awareness = "Content Marketing, Social Media Marketing, Display Advertising,";

                        if (user.Brand_Awareness != null && user.Lead_Generation != null)
                        {
                            ViewBag.Brand_Awareness = "Content Marketing, Social Media Marketing";
                        }


                        double bap = (Convert.ToInt32(user.Brand_Awareness_Priority)) + (Convert.ToInt32(user.Lead_Generation_Priority)) + (Convert.ToInt32(user.Sales_Generation_Priority)) + (Convert.ToInt32(user.Traffic_Generation_Priority));

                        switch (bap)
                        {


                            case 6:
                                double result63 = user.Budget1 / 5;
                                ViewBag.case63 = result63.ToString("0.00") + " " + user.Currency;
                                break;
                            case 10:
                                double result13 = user.Budget1 / 5;
                                ViewBag.case13 = result13.ToString("0.00") + " " + user.Currency;
                                break;
                            default:
                                ViewBag.BA_P1 = "Please check your inputs";
                                break;
                        }
                    }

                    if (user.Brand_Awareness != null && Convert.ToInt32(user.Brand_Awareness_Priority) == 4)
                    {
                        ViewBag.Brand_Awareness = "Content Marketing, Social Media Marketing, Display Advertising,";

                        if (user.Brand_Awareness != null && user.Lead_Generation != null)
                        {
                            ViewBag.Brand_Awareness = "Content Marketing, Social Media Marketing";
                        }


                        double bap = (Convert.ToInt32(user.Brand_Awareness_Priority)) + (Convert.ToInt32(user.Lead_Generation_Priority)) + (Convert.ToInt32(user.Sales_Generation_Priority)) + (Convert.ToInt32(user.Traffic_Generation_Priority));

                        switch (bap)
                        {

                            case 10:
                                double result14 = user.Budget1 / 10;
                                ViewBag.case14 = result14.ToString("0.00") + " " + user.Currency;
                                break;
                            default:
                                ViewBag.BA_P1 = "Please check your inputs";
                                break;
                        }
                    }

                    // Budget calculation for Lead Generation
                    if (user.Lead_Generation != null && Convert.ToInt32(user.Lead_Generation_Priority) == 1)
                    {
                        ViewBag.Lead_Gen1 = "Search Engine Optimization (SEO), Email marketing, Pay-Per-Click Advertising";
                        ViewBag.Lead_Gen2 = "Display Advertising, Blogging";

                        if (Convert.ToInt32(user.Subscribers) <= 1000)
                        {
                            ViewBag.Lead_Gen1 = "Search Engine Optimization (SEO), Pay-Per-Click Advertising";
                        }

                        if (user.Lead_Generation != null && user.Traffic_Generation != null)
                        {
                            ViewBag.Lead_Gen1 = "Pay-Per-Click Advertising, Email marketing";
                            ViewBag.Lead_Gen2 = "Display Advertising, Blogging";

                            if (Convert.ToInt32(user.Subscribers) <= 1000)
                            {
                                ViewBag.Lead_Gen1 = "Pay-Per-Click Advertising";
                            }
                        }


                        double bap = (Convert.ToInt32(user.Brand_Awareness_Priority)) + (Convert.ToInt32(user.Lead_Generation_Priority)) + (Convert.ToInt32(user.Sales_Generation_Priority)) + (Convert.ToInt32(user.Traffic_Generation_Priority));

                        switch (bap)
                        {
                            case 1:
                                double result1 = user.Budget1 / 1;
                                ViewBag.lead1 = result1.ToString("0.00") + " " + user.Currency;
                                break;
                            case 3:
                                double result31 = user.Budget1 / 1.6;
                                ViewBag.lead31 = result31.ToString("0.00") + " " + user.Currency;
                                break;
                            case 6:
                                double result61 = user.Budget1 / 2.2;
                                ViewBag.lead61 = result61.ToString("0.00") + " " + user.Currency;
                                break;
                            case 10:
                                double result10 = user.Budget1 / 2.5;
                                ViewBag.lead11 = result10.ToString("0.00") + " " + user.Currency;
                                break;
                            default:
                                ViewBag.BA_P1 = "Please check your inputs";
                                break;
                        }
                    }

                    if (user.Lead_Generation != null && Convert.ToInt32(user.Lead_Generation_Priority) == 2)
                    {
                        ViewBag.Lead_Gen1 = "Search Engine Optimization (SEO), Email marketing, Pay-Per-Click Advertising";
                        ViewBag.Lead_Gen2 = "Display Advertising, Blogging";

                        if (Convert.ToInt32(user.Subscribers) <= 1000)
                        {
                            ViewBag.Lead_Gen1 = "Search Engine Optimization (SEO), Pay-Per-Click Advertising";
                        }

                        if (user.Lead_Generation != null && user.Traffic_Generation != null)
                        {
                            ViewBag.Lead_Gen1 = "Pay-Per-Click Advertising, Email marketing";
                            ViewBag.Lead_Gen2 = "Display Advertising, Blogging";


                            if (Convert.ToInt32(user.Subscribers) <= 1000)
                            {
                                ViewBag.Lead_Gen1 = "Pay-Per-Click Advertising";
                            }
                        }


                        double bap = (Convert.ToInt32(user.Brand_Awareness_Priority)) + (Convert.ToInt32(user.Lead_Generation_Priority)) + (Convert.ToInt32(user.Sales_Generation_Priority)) + (Convert.ToInt32(user.Traffic_Generation_Priority));

                        switch (bap)
                        {

                            case 3:
                                double result32 = user.Budget1 / 2.666;
                                ViewBag.lead32 = result32.ToString("0.00") + " " + user.Currency;
                                break;
                            case 6:
                                double result62 = user.Budget1 / 2.85;
                                ViewBag.lead62 = result62.ToString("0.00") + " " + user.Currency;
                                break;
                            case 10:
                                double result12 = user.Budget1 / 3.33333;
                                ViewBag.lead12 = result12.ToString("0.00") + " " + user.Currency;
                                break;
                            default:
                                ViewBag.BA_P1 = "Please check your inputs";
                                break;
                        }
                    }

                    if (user.Lead_Generation != null && Convert.ToInt32(user.Lead_Generation_Priority) == 3)
                    {
                        ViewBag.Lead_Gen1 = "Search Engine Optimization (SEO), Email marketing, Pay-Per-Click Advertising";
                        ViewBag.Lead_Gen2 = "Display Advertising, Blogging";

                        if (Convert.ToInt32(user.Subscribers) <= 1000)
                        {
                            ViewBag.Lead_Gen1 = "Search Engine Optimization (SEO), Pay-Per-Click Advertising";
                        }

                        if (user.Lead_Generation != null && user.Traffic_Generation != null)
                        {
                            ViewBag.Lead_Gen1 = "Pay-Per-Click Advertising, Email marketing";
                            ViewBag.Lead_Gen2 = "Display Advertising, Blogging";

                            if (Convert.ToInt32(user.Subscribers) <= 1000)
                            {
                                ViewBag.Lead_Gen1 = "Pay-Per-Click Advertising";
                            }
                        }

                        double bap = (Convert.ToInt32(user.Brand_Awareness_Priority)) + (Convert.ToInt32(user.Lead_Generation_Priority)) + (Convert.ToInt32(user.Sales_Generation_Priority)) + (Convert.ToInt32(user.Traffic_Generation_Priority));

                        switch (bap)
                        {


                            case 6:
                                double result63 = user.Budget1 / 5;
                                ViewBag.lead63 = result63.ToString("0.00") + " " + user.Currency;
                                break;
                            case 10:
                                double result13 = user.Budget1 / 5;
                                ViewBag.lead13 = result13.ToString("0.00") + " " + user.Currency;
                                break;
                            default:
                                ViewBag.BA_P1 = "Please check your inputs";
                                break;
                        }
                    }

                    if (user.Lead_Generation != null && Convert.ToInt32(user.Lead_Generation_Priority) == 4)
                    {
                        ViewBag.Lead_Gen1 = "Search Engine Optimization (SEO), Email marketing, Pay-Per-Click Advertising";
                        ViewBag.Lead_Gen2 = "Display Advertising, Blogging";

                        if (Convert.ToInt32(user.Subscribers) <= 1000)
                        {
                            ViewBag.Lead_Gen1 = "Search Engine Optimization (SEO), Pay-Per-Click Advertising";
                        }


                        if (user.Lead_Generation != null && user.Traffic_Generation != null)
                        {
                            ViewBag.Lead_Gen1 = "Pay-Per-Click Advertising, Email marketing";
                            ViewBag.Lead_Gen2 = "Display Advertising, Blogging";

                            if (Convert.ToInt32(user.Subscribers) <= 1000)
                            {
                                ViewBag.Lead_Gen1 = "Pay-Per-Click Advertising";
                            }
                        }

                        double bap = (Convert.ToInt32(user.Brand_Awareness_Priority)) + (Convert.ToInt32(user.Lead_Generation_Priority)) + (Convert.ToInt32(user.Sales_Generation_Priority)) + (Convert.ToInt32(user.Traffic_Generation_Priority));

                        switch (bap)
                        {

                            case 10:
                                double result14 = user.Budget1 / 10;
                                ViewBag.lead14 = result14.ToString("0.00") + " " + user.Currency;
                                break;
                            default:
                                ViewBag.BA_P1 = "Please check your inputs";
                                break;
                        }
                    }

                    // Budget calculation for Sales Generation

                    if (user.Sales_Generation != null && Convert.ToInt32(user.Sales_Generation_Priority) == 1)
                    {
                        ViewBag.Sales_Gen = "Affiliate Marketing";

                        if (user.Sales_Generation != null && user.Lead_Generation != null)
                        {
                            ViewBag.Sales_Gen = "Affiliate Marketing";
                        }

                        double bap = (Convert.ToInt32(user.Brand_Awareness_Priority)) + (Convert.ToInt32(user.Lead_Generation_Priority)) + (Convert.ToInt32(user.Sales_Generation_Priority)) + (Convert.ToInt32(user.Traffic_Generation_Priority));

                        switch (bap)
                        {
                            case 1:
                                double result1 = user.Budget1 / 1;
                                ViewBag.sales1 = result1.ToString("0.00") + " " + user.Currency;
                                break;
                            case 3:
                                double result31 = user.Budget1 / 1.6;
                                ViewBag.sales31 = result31.ToString("0.00") + " " + user.Currency;
                                break;
                            case 6:
                                double result61 = user.Budget1 / 2.2;
                                ViewBag.sales61 = result61.ToString("0.00") + " " + user.Currency;
                                break;
                            case 10:
                                double result10 = user.Budget1 / 2.5;
                                ViewBag.sales11 = result10.ToString("0.00") + " " + user.Currency;
                                break;
                            default:
                                ViewBag.BA_P1 = "Please check your inputs";
                                break;
                        }

                    }


                    if (user.Sales_Generation != null && Convert.ToInt32(user.Sales_Generation_Priority) == 2)
                    {
                        ViewBag.Sales_Gen = "Affiliate Marketing";

                        if (user.Sales_Generation != null && user.Lead_Generation != null)
                        {
                            ViewBag.Sales_Gen = "Affiliate Marketing";
                        }

                        double bap = (Convert.ToInt32(user.Brand_Awareness_Priority)) + (Convert.ToInt32(user.Lead_Generation_Priority)) + (Convert.ToInt32(user.Sales_Generation_Priority)) + (Convert.ToInt32(user.Traffic_Generation_Priority));

                        switch (bap)
                        {

                            case 3:
                                double result32 = user.Budget1 / 2.666;
                                ViewBag.sales32 = result32.ToString("0.00") + " " + user.Currency;
                                break;
                            case 6:
                                double result62 = user.Budget1 / 2.85;
                                ViewBag.sales62 = result62.ToString("0.00") + " " + user.Currency;
                                break;
                            case 10:
                                double result12 = user.Budget1 / 3.33333;
                                ViewBag.sales12 = result12.ToString("0.00") + " " + user.Currency;
                                break;
                            default:
                                ViewBag.BA_P1 = "Please check your inputs";
                                break;
                        }

                    }

                    if (user.Sales_Generation != null && Convert.ToInt32(user.Sales_Generation_Priority) == 3)
                    {
                        ViewBag.Sales_Gen = "Affiliate Marketing";

                        if (user.Sales_Generation != null && user.Lead_Generation != null)
                        {
                            ViewBag.Sales_Gen = "Affiliate Marketing";
                        }

                        double bap = (Convert.ToInt32(user.Brand_Awareness_Priority)) + (Convert.ToInt32(user.Lead_Generation_Priority)) + (Convert.ToInt32(user.Sales_Generation_Priority)) + (Convert.ToInt32(user.Traffic_Generation_Priority));


                        switch (bap)
                        {


                            case 6:
                                double result63 = user.Budget1 / 5;
                                ViewBag.sales63 = result63.ToString("0.00") + " " + user.Currency;
                                break;
                            case 10:
                                double result13 = user.Budget1 / 5;
                                ViewBag.sales13 = result13.ToString("0.00") + " " + user.Currency;
                                break;
                            default:
                                ViewBag.BA_P1 = "Please check your inputs";
                                break;
                        }

                    }

                    if (user.Sales_Generation != null && Convert.ToInt32(user.Sales_Generation_Priority) == 4)
                    {
                        ViewBag.Sales_Gen = "Affiliate Marketing";

                        if (user.Sales_Generation != null && user.Lead_Generation != null)
                        {
                            ViewBag.Sales_Gen = "Affiliate Marketing";
                        }

                        double bap = (Convert.ToInt32(user.Brand_Awareness_Priority)) + (Convert.ToInt32(user.Lead_Generation_Priority)) + (Convert.ToInt32(user.Sales_Generation_Priority)) + (Convert.ToInt32(user.Traffic_Generation_Priority));


                        switch (bap)
                        {

                            case 10:
                                double result14 = user.Budget1 / 10;
                                ViewBag.sales14 = result14.ToString("0.00") + " " + user.Currency;
                                break;
                            default:
                                ViewBag.BA_P1 = "Please check your inputs";
                                break;
                        }

                    }

                    // Budget calculation for Traffic Generation



                    if (user.Traffic_Generation != null && Convert.ToInt32(user.Traffic_Generation_Priority) == 1)
                    {
                        ViewBag.Traffic_Gen = "Search Engine Optimization (SEO), Content Marketing";

                        if (user.Traffic_Generation != null && user.Brand_Awareness != null)
                        {
                            ViewBag.Traffic_Gen = "Search Engine Optimization (SEO)";
                        }

                        double bap = (Convert.ToInt32(user.Brand_Awareness_Priority)) + (Convert.ToInt32(user.Lead_Generation_Priority)) + (Convert.ToInt32(user.Sales_Generation_Priority)) + (Convert.ToInt32(user.Traffic_Generation_Priority));

                        switch (bap)
                        {
                            case 1:
                                double result1 = user.Budget1 / 1;
                                ViewBag.traf1 = result1.ToString("0.00") + " " + user.Currency;
                                break;
                            case 3:
                                double result31 = user.Budget1 / 1.6;
                                ViewBag.traf31 = result31.ToString("0.00") + " " + user.Currency;
                                break;
                            case 6:
                                double result61 = user.Budget1 / 2.2;
                                ViewBag.traf61 = result61.ToString("0.00") + " " + user.Currency;
                                break;
                            case 10:
                                double result10 = user.Budget1 / 2.5;
                                ViewBag.traf11 = result10.ToString("0.00") + " " + user.Currency;
                                break;
                            default:
                                ViewBag.BA_P1 = "Please check your inputs";
                                break;
                        }

                    }


                    if (user.Traffic_Generation != null && Convert.ToInt32(user.Traffic_Generation_Priority) == 2)
                    {
                        ViewBag.Traffic_Gen = "Search Engine Optimization (SEO), Content Marketing";

                        if (user.Traffic_Generation != null && user.Brand_Awareness != null)
                        {
                            ViewBag.Traffic_Gen = "Search Engine Optimization (SEO)";
                        }

                        double bap = (Convert.ToInt32(user.Brand_Awareness_Priority)) + (Convert.ToInt32(user.Lead_Generation_Priority)) + (Convert.ToInt32(user.Sales_Generation_Priority)) + (Convert.ToInt32(user.Traffic_Generation_Priority));

                        switch (bap)
                        {

                            case 3:
                                double result32 = user.Budget1 / 2.666;
                                ViewBag.traf32 = result32.ToString("0.00") + " " + user.Currency;
                                break;
                            case 6:
                                double result62 = user.Budget1 / 2.85;
                                ViewBag.traf62 = result62.ToString("0.00") + " " + user.Currency;
                                break;
                            case 10:
                                double result12 = user.Budget1 / 3.33333;
                                ViewBag.traf12 = result12.ToString("0.00") + " " + user.Currency;
                                break;
                            default:
                                ViewBag.BA_P1 = "Please check your inputs";
                                break;
                        }

                    }

                    if (user.Traffic_Generation != null && Convert.ToInt32(user.Traffic_Generation_Priority) == 3)
                    {
                        ViewBag.Traffic_Gen = "Search Engine Optimization (SEO), Content Marketing";

                        if (user.Traffic_Generation != null && user.Brand_Awareness != null)
                        {
                            ViewBag.Traffic_Gen = "Search Engine Optimization (SEO)";
                        }

                        double bap = (Convert.ToInt32(user.Brand_Awareness_Priority)) + (Convert.ToInt32(user.Lead_Generation_Priority)) + (Convert.ToInt32(user.Sales_Generation_Priority)) + (Convert.ToInt32(user.Traffic_Generation_Priority));

                        switch (bap)
                        {


                            case 6:
                                double result63 = user.Budget1 / 5;
                                ViewBag.traf63 = result63.ToString("0.00") + " " + user.Currency;
                                break;
                            case 10:
                                double result13 = user.Budget1 / 5;
                                ViewBag.traf13 = result13.ToString("0.00") + " " + user.Currency;
                                break;
                            default:
                                ViewBag.BA_P1 = "Please check your inputs";
                                break;
                        }

                    }

                    if (user.Traffic_Generation != null && Convert.ToInt32(user.Traffic_Generation_Priority) == 4)
                    {
                        ViewBag.Traffic_Gen = "Search Engine Optimization (SEO), Content Marketing";

                        if (user.Traffic_Generation != null && user.Brand_Awareness != null)
                        {
                            ViewBag.Traffic_Gen = "Search Engine Optimization (SEO)";
                        }

                        double bap = (Convert.ToInt32(user.Brand_Awareness_Priority)) + (Convert.ToInt32(user.Lead_Generation_Priority)) + (Convert.ToInt32(user.Sales_Generation_Priority)) + (Convert.ToInt32(user.Traffic_Generation_Priority));

                        switch (bap)
                        {

                            case 10:
                                double result14 = user.Budget1 / 10;
                                ViewBag.traf14 = result14.ToString("0.00") + " " + user.Currency;
                                break;
                            default:
                                ViewBag.BA_P1 = "Please check your inputs";
                                break;
                        }



                    }
                    return View(user);
                }

                else
                {
                    TempData["Error"] = "Please set your company goals and their priorities correctly!";
                    return RedirectToAction("Index", "Survey");

                }





            }




            return View();



        }


        // GET: 
        public ActionResult Plan()
        {
            HttpCookie myCookie = Request.Cookies["myCookie"];

            if (myCookie == null)
            {
                return new HttpUnauthorizedResult();
            }


            if (!string.IsNullOrEmpty(myCookie.Values["Name"]))

            {

                string Name = myCookie.Values["Name"];
                string Email = myCookie.Values["Email"];
                string ID = myCookie.Values["ID"];
                //Yes userId is found. Mission accomplished.

                ViewBag.User = Name;
                ViewBag.Email = Email;
                ViewBag.ID = ID;


                //Passing model to view
                ProjectContext db = new ProjectContext();

                var user = db.Survey.Where(x => x.Email_Address == Email).OrderByDescending(x => x.Start_Date).First();

                if (user.Brand_Awareness != null || user.Sales_Generation != null || user.Traffic_Generation != null || user.Lead_Generation != null && user.Brand_Awareness_Priority == "1" || user.Traffic_Generation_Priority == "1" || user.Lead_Generation_Priority == "1" || user.Sales_Generation_Priority == "1")
                {



                    // Budget calculation for Brand Awareness
                    if (user.Brand_Awareness != null && Convert.ToInt32(user.Brand_Awareness_Priority) == 1)
                    {



                        if (user.Brand_Awareness != null && user.Lead_Generation != null)
                        {
                            ViewBag.Brand_Awareness = "Content Marketing, Social Media Marketing";

                            string[] ba1;
                            ba1 = new string[2] { "Content Marketing", "Social Media Marketing" };
                            ViewBag.ba_array1 = ba1[0];
                            ViewBag.ba_array2 = ba1[1];




                            double bap = (Convert.ToInt32(user.Brand_Awareness_Priority)) + (Convert.ToInt32(user.Lead_Generation_Priority)) + (Convert.ToInt32(user.Sales_Generation_Priority)) + (Convert.ToInt32(user.Traffic_Generation_Priority));

                            switch (bap)
                            {
                                case 1:
                                    double result1 = user.Budget1 / 1;
                                    ViewBag.case1 = result1.ToString("0.00") + " " + user.Currency;
                                    break;
                                case 3:
                                    double result31 = user.Budget1 / 1.6;
                                    ViewBag.case31 = result31.ToString("0.00") + " " + user.Currency;
                                    ViewBag.plan1 = result31 / 2 + " " + user.Currency;
                                    break;
                                case 6:
                                    double result61 = user.Budget1 / 2.2;
                                    ViewBag.case61 = result61.ToString("0.00") + " " + user.Currency;
                                    ViewBag.plan1 = result61 / 2 + " " + user.Currency;
                                    break;
                                case 10:
                                    double result10 = user.Budget1 / 2.5;
                                    ViewBag.case11 = result10.ToString("0.00") + " " + user.Currency;
                                    ViewBag.plan1 = result10 / 2 + " " + user.Currency;
                                    break;
                                default:
                                    ViewBag.BA_P1 = "Please check your inputs";
                                    break;
                            }

                        }

                        else
                        {
                            string[] ba;
                            ba = new string[3] { "Content Marketing", "Social Media Marketing", "Display Advertising" };
                            ViewBag.ba_array1 = ba[0];
                            ViewBag.ba_array2 = ba[1];
                            ViewBag.ba_array3 = ba[2];

                            double bap = (Convert.ToInt32(user.Brand_Awareness_Priority)) + (Convert.ToInt32(user.Lead_Generation_Priority)) + (Convert.ToInt32(user.Sales_Generation_Priority)) + (Convert.ToInt32(user.Traffic_Generation_Priority));

                            switch (bap)
                            {
                                case 1:
                                    double result1 = user.Budget1 / 1;
                                    ViewBag.case1 = result1.ToString("0.00") + " " + user.Currency;
                                    break;
                                case 3:
                                    double result31 = user.Budget1 / 1.6;
                                    ViewBag.case31 = result31.ToString("0.00") + " " + user.Currency;
                                    ViewBag.plan2 = result31 / 3 + " " + user.Currency;
                                    break;
                                case 6:
                                    double result61 = user.Budget1 / 2.2;
                                    ViewBag.case61 = result61.ToString("0.00") + " " + user.Currency;
                                    ViewBag.plan2 = result61 / 3 + " " + user.Currency;
                                    break;
                                case 10:
                                    double result10 = user.Budget1 / 2.5;
                                    ViewBag.case11 = result10.ToString("0.00") + " " + user.Currency;
                                    ViewBag.plan2 = result10 / 3 + " " + user.Currency;
                                    break;
                                default:
                                    ViewBag.BA_P1 = "Please check your inputs";
                                    break;
                            }
                        }
                    }

                    if (user.Brand_Awareness != null && Convert.ToInt32(user.Brand_Awareness_Priority) == 2)
                    {


                        if (user.Brand_Awareness != null && user.Lead_Generation != null)
                        {
                            ViewBag.Brand_Awareness = "Content Marketing, Social Media Marketing";

                            string[] ba1;
                            ba1 = new string[2] { "Content Marketing", "Social Media Marketing" };
                            ViewBag.ba_array1 = ba1[0];
                            ViewBag.ba_array2 = ba1[1];



                            double bap = (Convert.ToInt32(user.Brand_Awareness_Priority)) + (Convert.ToInt32(user.Lead_Generation_Priority)) + (Convert.ToInt32(user.Sales_Generation_Priority)) + (Convert.ToInt32(user.Traffic_Generation_Priority));

                            switch (bap)
                            {

                                case 3:
                                    double result32 = user.Budget1 / 2.666;
                                    ViewBag.case32 = result32.ToString("0.00") + " " + user.Currency;
                                    ViewBag.plan1 = result32 / 2 + " " + user.Currency;
                                    break;
                                case 6:
                                    double result62 = user.Budget1 / 2.85;
                                    ViewBag.case62 = result62.ToString("0.00") + " " + user.Currency;
                                    ViewBag.plan1 = result62 / 2 + " " + user.Currency;
                                    break;
                                case 10:
                                    double result12 = user.Budget1 / 3.33333;
                                    ViewBag.case12 = result12.ToString("0.00") + " " + user.Currency;
                                    ViewBag.plan1 = result12 / 2 + " " + user.Currency;
                                    break;
                                default:
                                    ViewBag.BA_P1 = "Please check your inputs";
                                    break;
                            }

                        }
                        else
                        {

                            string[] ba;
                            ba = new string[3] { "Content Marketing", "Social Media Marketing", "Display Advertising" };
                            ViewBag.ba_array1 = ba[0];
                            ViewBag.ba_array2 = ba[1];
                            ViewBag.ba_array3 = ba[2];

                            double bap = (Convert.ToInt32(user.Brand_Awareness_Priority)) + (Convert.ToInt32(user.Lead_Generation_Priority)) + (Convert.ToInt32(user.Sales_Generation_Priority)) + (Convert.ToInt32(user.Traffic_Generation_Priority));

                            switch (bap)
                            {

                                case 3:
                                    double result32 = user.Budget1 / 2.666;
                                    ViewBag.case32 = result32.ToString("0.00") + " " + user.Currency;
                                    ViewBag.plan2 = result32 / 3 + " " + user.Currency;
                                    break;
                                case 6:
                                    double result62 = user.Budget1 / 2.85;
                                    ViewBag.case62 = result62.ToString("0.00") + " " + user.Currency;
                                    ViewBag.plan2 = result62 / 3 + " " + user.Currency;
                                    break;
                                case 10:
                                    double result12 = user.Budget1 / 3.33333;
                                    ViewBag.case12 = result12.ToString("0.00") + " " + user.Currency;
                                    ViewBag.plan2 = result12 / 3 + " " + user.Currency;
                                    break;
                                default:
                                    ViewBag.BA_P1 = "Please check your inputs";
                                    break;
                            }

                        }
                    }

                    if (user.Brand_Awareness != null && Convert.ToInt32(user.Brand_Awareness_Priority) == 3)
                    {


                        if (user.Brand_Awareness != null && user.Lead_Generation != null)
                        {
                            ViewBag.Brand_Awareness = "Content Marketing, Social Media Marketing";

                            string[] ba1;
                            ba1 = new string[2] { "Content Marketing", "Social Media Marketing" };
                            ViewBag.ba_array1 = ba1[0];
                            ViewBag.ba_array2 = ba1[1];



                            double bap = (Convert.ToInt32(user.Brand_Awareness_Priority)) + (Convert.ToInt32(user.Lead_Generation_Priority)) + (Convert.ToInt32(user.Sales_Generation_Priority)) + (Convert.ToInt32(user.Traffic_Generation_Priority));

                            switch (bap)
                            {


                                case 6:
                                    double result63 = user.Budget1 / 5;
                                    ViewBag.case63 = result63.ToString("0.00") + " " + user.Currency;
                                    ViewBag.plan1 = result63 / 2 + " " + user.Currency;
                                    break;
                                case 10:
                                    double result13 = user.Budget1 / 5;
                                    ViewBag.case13 = result13.ToString("0.00") + " " + user.Currency;
                                    ViewBag.plan1 = result13 / 2 + " " + user.Currency;
                                    break;
                                default:
                                    ViewBag.BA_P1 = "Please check your inputs";
                                    break;
                            }

                        }
                        else
                        {

                            string[] ba;
                            ba = new string[3] { "Content Marketing", "Social Media Marketing", "Display Advertising" };
                            ViewBag.ba_array1 = ba[0];
                            ViewBag.ba_array2 = ba[1];
                            ViewBag.ba_array3 = ba[2];

                            double bap = (Convert.ToInt32(user.Brand_Awareness_Priority)) + (Convert.ToInt32(user.Lead_Generation_Priority)) + (Convert.ToInt32(user.Sales_Generation_Priority)) + (Convert.ToInt32(user.Traffic_Generation_Priority));

                            switch (bap)
                            {


                                case 6:
                                    double result63 = user.Budget1 / 5;
                                    ViewBag.case63 = result63.ToString("0.00") + " " + user.Currency;
                                    ViewBag.plan2 = result63 / 3 + " " + user.Currency;
                                    break;
                                case 10:
                                    double result13 = user.Budget1 / 5;
                                    ViewBag.case13 = result13.ToString("0.00") + " " + user.Currency;
                                    ViewBag.plan2 = result13 / 3 + " " + user.Currency;
                                    break;
                                default:
                                    ViewBag.BA_P1 = "Please check your inputs";
                                    break;
                            }

                        }
                    }

                    if (user.Brand_Awareness != null && Convert.ToInt32(user.Brand_Awareness_Priority) == 4)
                    {


                        if (user.Brand_Awareness != null && user.Lead_Generation != null)
                        {
                            ViewBag.Brand_Awareness = "Content Marketing, Social Media Marketing";

                            string[] ba1;
                            ba1 = new string[2] { "Content Marketing", "Social Media Marketing" };
                            ViewBag.ba_array1 = ba1[0];
                            ViewBag.ba_array2 = ba1[1];



                            double bap = (Convert.ToInt32(user.Brand_Awareness_Priority)) + (Convert.ToInt32(user.Lead_Generation_Priority)) + (Convert.ToInt32(user.Sales_Generation_Priority)) + (Convert.ToInt32(user.Traffic_Generation_Priority));

                            switch (bap)
                            {

                                case 10:
                                    double result14 = user.Budget1 / 10;
                                    ViewBag.case14 = result14.ToString("0.00") + " " + user.Currency;
                                    ViewBag.plan1 = result14 / 2 + " " + user.Currency;
                                    break;
                                default:
                                    ViewBag.BA_P1 = "Please check your inputs";
                                    break;
                            }

                        }
                        else
                        {

                            string[] ba;
                            ba = new string[3] { "Content Marketing", "Social Media Marketing", "Display Advertising" };
                            ViewBag.ba_array1 = ba[0];
                            ViewBag.ba_array2 = ba[1];
                            ViewBag.ba_array3 = ba[2];

                            double bap = (Convert.ToInt32(user.Brand_Awareness_Priority)) + (Convert.ToInt32(user.Lead_Generation_Priority)) + (Convert.ToInt32(user.Sales_Generation_Priority)) + (Convert.ToInt32(user.Traffic_Generation_Priority));

                            switch (bap)
                            {

                                case 10:
                                    double result14 = user.Budget1 / 10;
                                    ViewBag.case14 = result14.ToString("0.00") + " " + user.Currency;
                                    ViewBag.plan2 = result14 / 3 + " " + user.Currency;
                                    break;
                                default:
                                    ViewBag.BA_P1 = "Please check your inputs";
                                    break;
                            }

                        }
                    }

                    // Budget calculation for Lead Generation
                    if (user.Lead_Generation != null && Convert.ToInt32(user.Lead_Generation_Priority) == 1)
                    {
                        if (user.Lead_Generation != null && user.Traffic_Generation != null)
                        {

                            if (Convert.ToInt32(user.Subscribers) <= 1000)
                            {
                                ViewBag.Lead_Gen1 = "Pay-Per-Click Advertising, Display Advertising, Blogging";

                                string[] lg4;
                                lg4 = new string[3] { "Pay-Per-Click Advertising", "Display Advertising", "Blogging" };
                                ViewBag.lg_array1 = lg4[0];
                                ViewBag.lg_array2 = lg4[1];
                                ViewBag.lg_array3 = lg4[2];

                                double bap = (Convert.ToInt32(user.Brand_Awareness_Priority)) + (Convert.ToInt32(user.Lead_Generation_Priority)) + (Convert.ToInt32(user.Sales_Generation_Priority)) + (Convert.ToInt32(user.Traffic_Generation_Priority));

                                switch (bap)
                                {
                                    case 1:
                                        double result1 = user.Budget1 / 1;
                                        ViewBag.lg1 = result1.ToString("0.00") + " " + user.Currency;
                                        break;
                                    case 3:
                                        double result31 = user.Budget1 / 1.6;
                                        ViewBag.lead31 = result31.ToString("0.00") + " " + user.Currency;
                                        ViewBag.lead1 = result31 / 3 + " " + user.Currency;
                                        break;
                                    case 6:
                                        double result61 = user.Budget1 / 2.2;
                                        ViewBag.lead61 = result61.ToString("0.00") + " " + user.Currency;
                                        ViewBag.lead1 = result61 / 3 + " " + user.Currency;
                                        break;
                                    case 10:
                                        double result10 = user.Budget1 / 2.5;
                                        ViewBag.lead11 = result10.ToString("0.00") + " " + user.Currency;
                                        ViewBag.lead1 = result10 / 3 + " " + user.Currency;
                                        break;
                                    default:
                                        ViewBag.BA_P1 = "Please check your inputs";
                                        break;
                                }

                            }
                            else
                            {
                                ViewBag.Lead_Gen1 = "Pay-Per-Click Advertising, Display Advertising, Blogging, Email marketing";

                                string[] lg3;
                                lg3 = new string[4] { "Pay-Per-Click Advertising", "Display Advertising", "Blogging", "Email marketing" };
                                ViewBag.lg_array1 = lg3[0];
                                ViewBag.lg_array2 = lg3[1];
                                ViewBag.lg_array3 = lg3[2];
                                ViewBag.lg_array4 = lg3[3];

                                double bap = (Convert.ToInt32(user.Brand_Awareness_Priority)) + (Convert.ToInt32(user.Lead_Generation_Priority)) + (Convert.ToInt32(user.Sales_Generation_Priority)) + (Convert.ToInt32(user.Traffic_Generation_Priority));

                                switch (bap)
                                {
                                    case 1:
                                        double result1 = user.Budget1 / 1;
                                        ViewBag.lead2 = result1.ToString("0.00") + " " + user.Currency;
                                        break;
                                    case 3:
                                        double result31 = user.Budget1 / 1.6;
                                        ViewBag.lead31 = result31.ToString("0.00") + " " + user.Currency;
                                        ViewBag.lead2 = result31 / 4 + " " + user.Currency;
                                        break;
                                    case 6:
                                        double result61 = user.Budget1 / 2.2;
                                        ViewBag.lead61 = result61.ToString("0.00") + " " + user.Currency;
                                        ViewBag.lead2 = result61 / 4 + " " + user.Currency;
                                        break;
                                    case 10:
                                        double result10 = user.Budget1 / 2.5;
                                        ViewBag.lead11 = result10.ToString("0.00") + " " + user.Currency;
                                        ViewBag.lead2 = result10 / 4 + " " + user.Currency;
                                        break;
                                    default:
                                        ViewBag.BA_P1 = "Please check your inputs";
                                        break;
                                }
                            }
                        }

                        else
                        {
                            if (Convert.ToInt32(user.Subscribers) <= 1000)
                            {
                                ViewBag.Lead_Gen1 = "Search Engine Optimization (SEO), Pay-Per-Click Advertising";
                                ViewBag.Lead_Gen2 = "Display Advertising, Blogging";

                                string[] lg2;
                                lg2 = new string[4] { "Pay-Per-Click Advertising", "Display Advertising", "Blogging", "Search Engine Optimization (SEO)" };
                                ViewBag.lg_array1 = lg2[0];
                                ViewBag.lg_array2 = lg2[1];
                                ViewBag.lg_array3 = lg2[2];
                                ViewBag.lg_array4 = lg2[3];

                                double bap = (Convert.ToInt32(user.Brand_Awareness_Priority)) + (Convert.ToInt32(user.Lead_Generation_Priority)) + (Convert.ToInt32(user.Sales_Generation_Priority)) + (Convert.ToInt32(user.Traffic_Generation_Priority));

                                switch (bap)
                                {
                                    case 1:
                                        double result1 = user.Budget1 / 1;
                                        ViewBag.lead2 = result1.ToString("0.00") + " " + user.Currency;
                                        break;
                                    case 3:
                                        double result31 = user.Budget1 / 1.6;
                                        ViewBag.lead31 = result31.ToString("0.00") + " " + user.Currency;
                                        ViewBag.lead2 = result31 / 4 + " " + user.Currency;
                                        break;
                                    case 6:
                                        double result61 = user.Budget1 / 2.2;
                                        ViewBag.lead61 = result61.ToString("0.00") + " " + user.Currency;
                                        ViewBag.lead2 = result61 / 4 + " " + user.Currency;
                                        break;
                                    case 10:
                                        double result10 = user.Budget1 / 2.5;
                                        ViewBag.lead11 = result10.ToString("0.00") + " " + user.Currency;
                                        ViewBag.lead2 = result10 / 4 + " " + user.Currency;
                                        break;
                                    default:
                                        ViewBag.BA_P1 = "Please check your inputs";
                                        break;
                                }

                            }
                            else
                            {
                                ViewBag.Lead_Gen1 = "Search Engine Optimization (SEO), Email marketing, Pay-Per-Click Advertising";
                                ViewBag.Lead_Gen2 = "Display Advertising, Blogging";
                                string[] lg1;
                                lg1 = new string[5] { "Pay-Per-Click Advertising", "Display Advertising", "Blogging", "Search Engine Optimization (SEO)", "Email marketing" };
                                ViewBag.lg_array1 = lg1[0];
                                ViewBag.lg_array2 = lg1[1];
                                ViewBag.lg_array3 = lg1[2];
                                ViewBag.lg_array4 = lg1[3];
                                ViewBag.lg_array5 = lg1[4];

                                double bap = (Convert.ToInt32(user.Brand_Awareness_Priority)) + (Convert.ToInt32(user.Lead_Generation_Priority)) + (Convert.ToInt32(user.Sales_Generation_Priority)) + (Convert.ToInt32(user.Traffic_Generation_Priority));
                                switch (bap)
                                {
                                    case 1:
                                        double result1 = user.Budget1 / 1;
                                        ViewBag.lead4 = result1.ToString("0.00") + " " + user.Currency;
                                        break;
                                    case 3:
                                        double result31 = user.Budget1 / 1.6;
                                        ViewBag.lead31 = result31.ToString("0.00") + " " + user.Currency;
                                        ViewBag.lead3 = result31 / 5 + " " + user.Currency;
                                        break;
                                    case 6:
                                        double result61 = user.Budget1 / 2.2;
                                        ViewBag.lead61 = result61.ToString("0.00") + " " + user.Currency;
                                        ViewBag.lead3 = result61 / 5 + " " + user.Currency;
                                        break;
                                    case 10:
                                        double result10 = user.Budget1 / 2.5;
                                        ViewBag.lead11 = result10.ToString("0.00") + " " + user.Currency;
                                        ViewBag.lead3 = result10 / 5 + " " + user.Currency;
                                        break;
                                    default:
                                        ViewBag.BA_P1 = "Please check your inputs";
                                        break;
                                }
                            }
                        }

                    }


                    if (user.Lead_Generation != null && Convert.ToInt32(user.Lead_Generation_Priority) == 2)
                    {
                        if (user.Lead_Generation != null && user.Traffic_Generation != null)
                        {

                            if (Convert.ToInt32(user.Subscribers) <= 1000)
                            {
                                ViewBag.Lead_Gen1 = "Pay-Per-Click Advertising, Display Advertising, Blogging";

                                string[] lg4;
                                lg4 = new string[3] { "Pay-Per-Click Advertising", "Display Advertising", "Blogging" };
                                ViewBag.lg_array1 = lg4[0];
                                ViewBag.lg_array2 = lg4[1];
                                ViewBag.lg_array3 = lg4[2];

                                double bap = (Convert.ToInt32(user.Brand_Awareness_Priority)) + (Convert.ToInt32(user.Lead_Generation_Priority)) + (Convert.ToInt32(user.Sales_Generation_Priority)) + (Convert.ToInt32(user.Traffic_Generation_Priority));

                                switch (bap)
                                {

                                    case 3:
                                        double result32 = user.Budget1 / 2.666;
                                        ViewBag.lead32 = result32.ToString("0.00") + " " + user.Currency;
                                        ViewBag.lead1 = result32 / 3 + " " + user.Currency;
                                        break;
                                    case 6:
                                        double result62 = user.Budget1 / 2.85;
                                        ViewBag.lead62 = result62.ToString("0.00") + " " + user.Currency;
                                        ViewBag.lead1 = result62 / 3 + " " + user.Currency;
                                        break;
                                    case 10:
                                        double result12 = user.Budget1 / 3.33333;
                                        ViewBag.lead12 = result12.ToString("0.00") + " " + user.Currency;
                                        ViewBag.lead1 = result12 / 3 + " " + user.Currency;
                                        break;
                                    default:
                                        ViewBag.BA_P1 = "Please check your inputs";
                                        break;
                                }

                            }
                            else
                            {
                                ViewBag.Lead_Gen1 = "Pay-Per-Click Advertising, Display Advertising, Blogging, Email marketing";

                                string[] lg3;
                                lg3 = new string[4] { "Pay-Per-Click Advertising", "Display Advertising", "Blogging", "Email marketing" };
                                ViewBag.lg_array1 = lg3[0];
                                ViewBag.lg_array2 = lg3[1];
                                ViewBag.lg_array3 = lg3[2];
                                ViewBag.lg_array4 = lg3[3];

                                double bap = (Convert.ToInt32(user.Brand_Awareness_Priority)) + (Convert.ToInt32(user.Lead_Generation_Priority)) + (Convert.ToInt32(user.Sales_Generation_Priority)) + (Convert.ToInt32(user.Traffic_Generation_Priority));

                                switch (bap)
                                {

                                    case 3:
                                        double result32 = user.Budget1 / 2.666;
                                        ViewBag.lead32 = result32.ToString("0.00") + " " + user.Currency;
                                        ViewBag.lead2 = result32 / 4 + " " + user.Currency;
                                        break;
                                    case 6:
                                        double result62 = user.Budget1 / 2.85;
                                        ViewBag.lead62 = result62.ToString("0.00") + " " + user.Currency;
                                        ViewBag.lead2 = result62 / 4 + " " + user.Currency;
                                        break;
                                    case 10:
                                        double result12 = user.Budget1 / 3.33333;
                                        ViewBag.lead12 = result12.ToString("0.00") + " " + user.Currency;
                                        ViewBag.lead2 = result12 / 4 + " " + user.Currency;
                                        break;
                                    default:
                                        ViewBag.BA_P1 = "Please check your inputs";
                                        break;
                                }
                            }
                        }

                        else
                        {
                            if (Convert.ToInt32(user.Subscribers) <= 1000)
                            {
                                ViewBag.Lead_Gen1 = "Search Engine Optimization (SEO), Pay-Per-Click Advertising";
                                ViewBag.Lead_Gen2 = "Display Advertising, Blogging";

                                string[] lg2;
                                lg2 = new string[4] { "Pay-Per-Click Advertising", "Display Advertising", "Blogging", "Search Engine Optimization (SEO)" };
                                ViewBag.lg_array1 = lg2[0];
                                ViewBag.lg_array2 = lg2[1];
                                ViewBag.lg_array3 = lg2[2];
                                ViewBag.lg_array4 = lg2[3];

                                double bap = (Convert.ToInt32(user.Brand_Awareness_Priority)) + (Convert.ToInt32(user.Lead_Generation_Priority)) + (Convert.ToInt32(user.Sales_Generation_Priority)) + (Convert.ToInt32(user.Traffic_Generation_Priority));

                                switch (bap)
                                {

                                    case 3:
                                        double result32 = user.Budget1 / 2.666;
                                        ViewBag.lead32 = result32.ToString("0.00") + " " + user.Currency;
                                        ViewBag.lead2 = result32 / 4 + " " + user.Currency;
                                        break;
                                    case 6:
                                        double result62 = user.Budget1 / 2.85;
                                        ViewBag.lead62 = result62.ToString("0.00") + " " + user.Currency;
                                        ViewBag.lead2 = result62 / 4 + " " + user.Currency;
                                        break;
                                    case 10:
                                        double result12 = user.Budget1 / 3.33333;
                                        ViewBag.lead12 = result12.ToString("0.00") + " " + user.Currency;
                                        ViewBag.lead2 = result12 / 4 + " " + user.Currency;
                                        break;
                                    default:
                                        ViewBag.BA_P1 = "Please check your inputs";
                                        break;
                                }

                            }
                            else
                            {
                                ViewBag.Lead_Gen1 = "Search Engine Optimization (SEO), Email marketing, Pay-Per-Click Advertising";
                                ViewBag.Lead_Gen2 = "Display Advertising, Blogging";
                                string[] lg1;
                                lg1 = new string[5] { "Pay-Per-Click Advertising", "Display Advertising", "Blogging", "Search Engine Optimization (SEO)", "Email marketing" };
                                ViewBag.lg_array1 = lg1[0];
                                ViewBag.lg_array2 = lg1[1];
                                ViewBag.lg_array3 = lg1[2];
                                ViewBag.lg_array4 = lg1[3];
                                ViewBag.lg_array5 = lg1[4];

                                double bap = (Convert.ToInt32(user.Brand_Awareness_Priority)) + (Convert.ToInt32(user.Lead_Generation_Priority)) + (Convert.ToInt32(user.Sales_Generation_Priority)) + (Convert.ToInt32(user.Traffic_Generation_Priority));
                                switch (bap)
                                {

                                    case 3:
                                        double result32 = user.Budget1 / 2.666;
                                        ViewBag.lead32 = result32.ToString("0.00") + " " + user.Currency;
                                        ViewBag.lead3 = result32 / 5 + " " + user.Currency;
                                        break;
                                    case 6:
                                        double result62 = user.Budget1 / 2.85;
                                        ViewBag.lead62 = result62.ToString("0.00") + " " + user.Currency;
                                        ViewBag.lead3 = result62 / 5 + " " + user.Currency;
                                        break;
                                    case 10:
                                        double result12 = user.Budget1 / 3.33333;
                                        ViewBag.lead12 = result12.ToString("0.00") + " " + user.Currency;
                                        ViewBag.lead3 = result12 / 5 + " " + user.Currency;
                                        break;
                                    default:
                                        ViewBag.BA_P1 = "Please check your inputs";
                                        break;
                                }
                            }
                        }

                    }


                    if (user.Lead_Generation != null && Convert.ToInt32(user.Lead_Generation_Priority) == 3)

                    {
                        if (user.Lead_Generation != null && user.Traffic_Generation != null)
                        {

                            if (Convert.ToInt32(user.Subscribers) <= 1000)
                            {
                                ViewBag.Lead_Gen1 = "Pay-Per-Click Advertising, Display Advertising, Blogging";

                                string[] lg4;
                                lg4 = new string[3] { "Pay-Per-Click Advertising", "Display Advertising", "Blogging" };
                                ViewBag.lg_array1 = lg4[0];
                                ViewBag.lg_array2 = lg4[1];
                                ViewBag.lg_array3 = lg4[2];

                                double bap = (Convert.ToInt32(user.Brand_Awareness_Priority)) + (Convert.ToInt32(user.Lead_Generation_Priority)) + (Convert.ToInt32(user.Sales_Generation_Priority)) + (Convert.ToInt32(user.Traffic_Generation_Priority));

                                switch (bap)
                                {


                                    case 6:
                                        double result63 = user.Budget1 / 5;
                                        ViewBag.lead63 = result63.ToString("0.00") + " " + user.Currency;
                                        ViewBag.lead1 = result63 / 3 + " " + user.Currency;
                                        break;
                                    case 10:
                                        double result13 = user.Budget1 / 5;
                                        ViewBag.lead13 = result13.ToString("0.00") + " " + user.Currency;
                                        ViewBag.lead1 = result13 / 3 + " " + user.Currency;
                                        break;
                                    default:
                                        ViewBag.BA_P1 = "Please check your inputs";
                                        break;
                                }

                            }
                            else
                            {
                                ViewBag.Lead_Gen1 = "Pay-Per-Click Advertising, Display Advertising, Blogging, Email marketing";

                                string[] lg3;
                                lg3 = new string[4] { "Pay-Per-Click Advertising", "Display Advertising", "Blogging", "Email marketing" };
                                ViewBag.lg_array1 = lg3[0];
                                ViewBag.lg_array2 = lg3[1];
                                ViewBag.lg_array3 = lg3[2];
                                ViewBag.lg_array4 = lg3[3];

                                double bap = (Convert.ToInt32(user.Brand_Awareness_Priority)) + (Convert.ToInt32(user.Lead_Generation_Priority)) + (Convert.ToInt32(user.Sales_Generation_Priority)) + (Convert.ToInt32(user.Traffic_Generation_Priority));

                                switch (bap)
                                {

                                    case 6:
                                        double result63 = user.Budget1 / 5;
                                        ViewBag.lead63 = result63.ToString("0.00") + " " + user.Currency;
                                        ViewBag.lead2 = result63 / 4 + " " + user.Currency;
                                        break;
                                    case 10:
                                        double result13 = user.Budget1 / 5;
                                        ViewBag.lead13 = result13.ToString("0.00") + " " + user.Currency;
                                        ViewBag.lead2 = result13 / 4 + " " + user.Currency;
                                        break;
                                    default:
                                        ViewBag.BA_P1 = "Please check your inputs";
                                        break;
                                }
                            }
                        }

                        else
                        {
                            if (Convert.ToInt32(user.Subscribers) <= 1000)
                            {
                                ViewBag.Lead_Gen1 = "Search Engine Optimization (SEO), Pay-Per-Click Advertising";
                                ViewBag.Lead_Gen2 = "Display Advertising, Blogging";

                                string[] lg2;
                                lg2 = new string[4] { "Pay-Per-Click Advertising", "Display Advertising", "Blogging", "Search Engine Optimization (SEO)" };
                                ViewBag.lg_array1 = lg2[0];
                                ViewBag.lg_array2 = lg2[1];
                                ViewBag.lg_array3 = lg2[2];
                                ViewBag.lg_array4 = lg2[3];

                                double bap = (Convert.ToInt32(user.Brand_Awareness_Priority)) + (Convert.ToInt32(user.Lead_Generation_Priority)) + (Convert.ToInt32(user.Sales_Generation_Priority)) + (Convert.ToInt32(user.Traffic_Generation_Priority));

                                switch (bap)
                                {

                                    case 6:
                                        double result63 = user.Budget1 / 5;
                                        ViewBag.lead63 = result63.ToString("0.00") + " " + user.Currency;
                                        ViewBag.lead2 = result63 / 4 + " " + user.Currency;
                                        break;
                                    case 10:
                                        double result13 = user.Budget1 / 5;
                                        ViewBag.lead13 = result13.ToString("0.00") + " " + user.Currency;
                                        ViewBag.lead2 = result13 / 4 + " " + user.Currency;
                                        break;
                                    default:
                                        ViewBag.BA_P1 = "Please check your inputs";
                                        break;
                                }

                            }
                            else
                            {
                                ViewBag.Lead_Gen1 = "Search Engine Optimization (SEO), Email marketing, Pay-Per-Click Advertising";
                                ViewBag.Lead_Gen2 = "Display Advertising, Blogging";
                                string[] lg1;
                                lg1 = new string[5] { "Pay-Per-Click Advertising", "Display Advertising", "Blogging", "Search Engine Optimization (SEO)", "Email marketing" };
                                ViewBag.lg_array1 = lg1[0];
                                ViewBag.lg_array2 = lg1[1];
                                ViewBag.lg_array3 = lg1[2];
                                ViewBag.lg_array4 = lg1[3];
                                ViewBag.lg_array5 = lg1[4];

                                double bap = (Convert.ToInt32(user.Brand_Awareness_Priority)) + (Convert.ToInt32(user.Lead_Generation_Priority)) + (Convert.ToInt32(user.Sales_Generation_Priority)) + (Convert.ToInt32(user.Traffic_Generation_Priority));
                                switch (bap)
                                {

                                    case 6:
                                        double result63 = user.Budget1 / 5;
                                        ViewBag.lead63 = result63.ToString("0.00") + " " + user.Currency;
                                        ViewBag.lead3 = result63 / 5 + " " + user.Currency;
                                        break;
                                    case 10:
                                        double result13 = user.Budget1 / 5;
                                        ViewBag.lead13 = result13.ToString("0.00") + " " + user.Currency;
                                        ViewBag.lead3 = result13 / 5 + " " + user.Currency;
                                        break;
                                    default:
                                        ViewBag.BA_P1 = "Please check your inputs";
                                        break;
                                }
                            }
                        }

                    }






                    if (user.Lead_Generation != null && Convert.ToInt32(user.Lead_Generation_Priority) == 4)


                    {
                        if (user.Lead_Generation != null && user.Traffic_Generation != null)
                        {

                            if (Convert.ToInt32(user.Subscribers) <= 1000)
                            {
                                ViewBag.Lead_Gen1 = "Pay-Per-Click Advertising, Display Advertising, Blogging";

                                string[] lg4;
                                lg4 = new string[3] { "Pay-Per-Click Advertising", "Display Advertising", "Blogging" };
                                ViewBag.lg_array1 = lg4[0];
                                ViewBag.lg_array2 = lg4[1];
                                ViewBag.lg_array3 = lg4[2];

                                double bap = (Convert.ToInt32(user.Brand_Awareness_Priority)) + (Convert.ToInt32(user.Lead_Generation_Priority)) + (Convert.ToInt32(user.Sales_Generation_Priority)) + (Convert.ToInt32(user.Traffic_Generation_Priority));

                                switch (bap)
                                {


                                    case 10:
                                        double result14 = user.Budget1 / 10;
                                        ViewBag.lead14 = result14.ToString("0.00") + " " + user.Currency;
                                        ViewBag.lead1 = result14 / 3 + " " + user.Currency;
                                        break;
                                    default:
                                        ViewBag.BA_P1 = "Please check your inputs";
                                        break;


                                }

                            }
                            else
                            {
                                ViewBag.Lead_Gen1 = "Pay-Per-Click Advertising, Display Advertising, Blogging, Email marketing";

                                string[] lg3;
                                lg3 = new string[4] { "Pay-Per-Click Advertising", "Display Advertising", "Blogging", "Email marketing" };
                                ViewBag.lg_array1 = lg3[0];
                                ViewBag.lg_array2 = lg3[1];
                                ViewBag.lg_array3 = lg3[2];
                                ViewBag.lg_array4 = lg3[3];

                                double bap = (Convert.ToInt32(user.Brand_Awareness_Priority)) + (Convert.ToInt32(user.Lead_Generation_Priority)) + (Convert.ToInt32(user.Sales_Generation_Priority)) + (Convert.ToInt32(user.Traffic_Generation_Priority));

                                switch (bap)
                                {


                                    case 10:
                                        double result14 = user.Budget1 / 10;
                                        ViewBag.lead14 = result14.ToString("0.00") + " " + user.Currency;
                                        ViewBag.lead2 = result14 / 4 + " " + user.Currency;
                                        break;
                                    default:
                                        ViewBag.BA_P1 = "Please check your inputs";
                                        break;

                                }
                            }
                        }

                        else
                        {
                            if (Convert.ToInt32(user.Subscribers) <= 1000)
                            {
                                ViewBag.Lead_Gen1 = "Search Engine Optimization (SEO), Pay-Per-Click Advertising";
                                ViewBag.Lead_Gen2 = "Display Advertising, Blogging";

                                string[] lg2;
                                lg2 = new string[4] { "Pay-Per-Click Advertising", "Display Advertising", "Blogging", "Search Engine Optimization (SEO)" };
                                ViewBag.lg_array1 = lg2[0];
                                ViewBag.lg_array2 = lg2[1];
                                ViewBag.lg_array3 = lg2[2];
                                ViewBag.lg_array4 = lg2[3];

                                double bap = (Convert.ToInt32(user.Brand_Awareness_Priority)) + (Convert.ToInt32(user.Lead_Generation_Priority)) + (Convert.ToInt32(user.Sales_Generation_Priority)) + (Convert.ToInt32(user.Traffic_Generation_Priority));

                                switch (bap)
                                {


                                    case 10:
                                        double result14 = user.Budget1 / 10;
                                        ViewBag.lead14 = result14.ToString("0.00") + " " + user.Currency;
                                        ViewBag.lead2 = result14 / 4 + " " + user.Currency;
                                        break;
                                    default:
                                        ViewBag.BA_P1 = "Please check your inputs";
                                        break;

                                }

                            }
                            else
                            {
                                ViewBag.Lead_Gen1 = "Search Engine Optimization (SEO), Email marketing, Pay-Per-Click Advertising";
                                ViewBag.Lead_Gen2 = "Display Advertising, Blogging";
                                string[] lg1;
                                lg1 = new string[5] { "Pay-Per-Click Advertising", "Display Advertising", "Blogging", "Search Engine Optimization (SEO)", "Email marketing" };
                                ViewBag.lg_array1 = lg1[0];
                                ViewBag.lg_array2 = lg1[1];
                                ViewBag.lg_array3 = lg1[2];
                                ViewBag.lg_array4 = lg1[3];
                                ViewBag.lg_array5 = lg1[4];

                                double bap = (Convert.ToInt32(user.Brand_Awareness_Priority)) + (Convert.ToInt32(user.Lead_Generation_Priority)) + (Convert.ToInt32(user.Sales_Generation_Priority)) + (Convert.ToInt32(user.Traffic_Generation_Priority));
                                switch (bap)
                                {

                                    case 10:
                                        double result14 = user.Budget1 / 10;
                                        ViewBag.lead14 = result14.ToString("0.00") + " " + user.Currency;
                                        ViewBag.lead3 = result14 / 5 + " " + user.Currency;
                                        break;
                                    default:
                                        ViewBag.BA_P1 = "Please check your inputs";
                                        break;


                                }
                            }
                        }

                    }




                    // Budget calculation for Sales Generation

                    if (user.Sales_Generation != null && Convert.ToInt32(user.Sales_Generation_Priority) == 1)
                    {
                        ViewBag.Sales_Gen = "Affiliate Marketing";



                        if (user.Sales_Generation != null && user.Lead_Generation != null)
                        {
                            ViewBag.Sales_Gen = "Affiliate Marketing";
                        }

                        double bap = (Convert.ToInt32(user.Brand_Awareness_Priority)) + (Convert.ToInt32(user.Lead_Generation_Priority)) + (Convert.ToInt32(user.Sales_Generation_Priority)) + (Convert.ToInt32(user.Traffic_Generation_Priority));

                        switch (bap)
                        {
                            case 1:
                                double result1 = user.Budget1 / 1;
                                ViewBag.sales1 = result1.ToString("0.00") + " " + user.Currency;
                                break;
                            case 3:
                                double result31 = user.Budget1 / 1.6;
                                ViewBag.sales31 = result31.ToString("0.00") + " " + user.Currency;
                                break;
                            case 6:
                                double result61 = user.Budget1 / 2.2;
                                ViewBag.sales61 = result61.ToString("0.00") + " " + user.Currency;
                                break;
                            case 10:
                                double result10 = user.Budget1 / 2.5;
                                ViewBag.sales11 = result10.ToString("0.00") + " " + user.Currency;
                                break;
                            default:
                                ViewBag.BA_P1 = "Please check your inputs";
                                break;
                        }

                    }


                    if (user.Sales_Generation != null && Convert.ToInt32(user.Sales_Generation_Priority) == 2)
                    {
                        ViewBag.Sales_Gen = "Affiliate Marketing";

                        if (user.Sales_Generation != null && user.Lead_Generation != null)
                        {
                            ViewBag.Sales_Gen = "Affiliate Marketing";
                        }

                        double bap = (Convert.ToInt32(user.Brand_Awareness_Priority)) + (Convert.ToInt32(user.Lead_Generation_Priority)) + (Convert.ToInt32(user.Sales_Generation_Priority)) + (Convert.ToInt32(user.Traffic_Generation_Priority));

                        switch (bap)
                        {

                            case 3:
                                double result32 = user.Budget1 / 2.666;
                                ViewBag.sales32 = result32.ToString("0.00") + " " + user.Currency;
                                break;
                            case 6:
                                double result62 = user.Budget1 / 2.85;
                                ViewBag.sales62 = result62.ToString("0.00") + " " + user.Currency;
                                break;
                            case 10:
                                double result12 = user.Budget1 / 3.33333;
                                ViewBag.sales12 = result12.ToString("0.00") + " " + user.Currency;
                                break;
                            default:
                                ViewBag.BA_P1 = "Please check your inputs";
                                break;
                        }

                    }

                    if (user.Sales_Generation != null && Convert.ToInt32(user.Sales_Generation_Priority) == 3)
                    {
                        ViewBag.Sales_Gen = "Affiliate Marketing";

                        if (user.Sales_Generation != null && user.Lead_Generation != null)
                        {
                            ViewBag.Sales_Gen = "Affiliate Marketing";
                        }

                        double bap = (Convert.ToInt32(user.Brand_Awareness_Priority)) + (Convert.ToInt32(user.Lead_Generation_Priority)) + (Convert.ToInt32(user.Sales_Generation_Priority)) + (Convert.ToInt32(user.Traffic_Generation_Priority));


                        switch (bap)
                        {


                            case 6:
                                double result63 = user.Budget1 / 5;
                                ViewBag.sales63 = result63.ToString("0.00") + " " + user.Currency;
                                break;
                            case 10:
                                double result13 = user.Budget1 / 5;
                                ViewBag.sales13 = result13.ToString("0.00") + " " + user.Currency;
                                break;
                            default:
                                ViewBag.BA_P1 = "Please check your inputs";
                                break;
                        }

                    }

                    if (user.Sales_Generation != null && Convert.ToInt32(user.Sales_Generation_Priority) == 4)
                    {
                        ViewBag.Sales_Gen = "Affiliate Marketing";

                        if (user.Sales_Generation != null && user.Lead_Generation != null)
                        {
                            ViewBag.Sales_Gen = "Affiliate Marketing";
                        }

                        double bap = (Convert.ToInt32(user.Brand_Awareness_Priority)) + (Convert.ToInt32(user.Lead_Generation_Priority)) + (Convert.ToInt32(user.Sales_Generation_Priority)) + (Convert.ToInt32(user.Traffic_Generation_Priority));


                        switch (bap)
                        {

                            case 10:
                                double result14 = user.Budget1 / 10;
                                ViewBag.sales14 = result14.ToString("0.00") + " " + user.Currency;
                                break;
                            default:
                                ViewBag.BA_P1 = "Please check your inputs";
                                break;
                        }

                    }

                    // Budget calculation for Traffic Generation



                    if (user.Traffic_Generation != null && Convert.ToInt32(user.Traffic_Generation_Priority) == 1)
                    {


                        if (user.Traffic_Generation != null && user.Brand_Awareness != null)
                        {
                            ViewBag.Traffic_Gen = "Search Engine Optimization (SEO)";

                            double bap = (Convert.ToInt32(user.Brand_Awareness_Priority)) + (Convert.ToInt32(user.Lead_Generation_Priority)) + (Convert.ToInt32(user.Sales_Generation_Priority)) + (Convert.ToInt32(user.Traffic_Generation_Priority));

                            switch (bap)
                            {
                                case 1:
                                    double result1 = user.Budget1 / 1;
                                    ViewBag.traf1 = result1.ToString("0.00") + " " + user.Currency;
                                    break;
                                case 3:
                                    double result31 = user.Budget1 / 1.6;
                                    ViewBag.traf31 = result31.ToString("0.00") + " " + user.Currency;
                                    break;
                                case 6:
                                    double result61 = user.Budget1 / 2.2;
                                    ViewBag.traf61 = result61.ToString("0.00") + " " + user.Currency;
                                    break;
                                case 10:
                                    double result10 = user.Budget1 / 2.5;
                                    ViewBag.traf11 = result10.ToString("0.00") + " " + user.Currency;
                                    break;
                                default:
                                    ViewBag.BA_P1 = "Please check your inputs";
                                    break;
                            }
                        }

                        else
                        {

                            ViewBag.Traffic_Gen1 = "Search Engine Optimization (SEO), Content Marketing";

                            string[] tf1;
                            tf1 = new string[2] { "Search Engine Optimization (SEO)", "Content Marketing" };
                            ViewBag.tf_array1 = tf1[0];
                            ViewBag.tf_array2 = tf1[1];

                            double bap = (Convert.ToInt32(user.Brand_Awareness_Priority)) + (Convert.ToInt32(user.Lead_Generation_Priority)) + (Convert.ToInt32(user.Sales_Generation_Priority)) + (Convert.ToInt32(user.Traffic_Generation_Priority));

                            switch (bap)
                            {
                                case 1:
                                    double result1 = user.Budget1 / 1;

                                    ViewBag.trafs = result1 / 2 + " " + user.Currency;
                                    break;
                                case 3:
                                    double result31 = user.Budget1 / 1.6;

                                    ViewBag.trafs = result31 / 2 + " " + user.Currency;
                                    break;
                                case 6:
                                    double result61 = user.Budget1 / 2.2;

                                    ViewBag.trafs = result61 / 2 + " " + user.Currency;
                                    break;
                                case 10:
                                    double result10 = user.Budget1 / 2.5;

                                    ViewBag.trafs = result10 / 2 + " " + user.Currency;
                                    break;
                                default:
                                    ViewBag.BA_P1 = "Please check your inputs";
                                    break;
                            }
                        }



                    }


                    if (user.Traffic_Generation != null && Convert.ToInt32(user.Traffic_Generation_Priority) == 2)
                    {


                        if (user.Traffic_Generation != null && user.Brand_Awareness != null)
                        {
                            ViewBag.Traffic_Gen = "Search Engine Optimization (SEO)";

                            double bap = (Convert.ToInt32(user.Brand_Awareness_Priority)) + (Convert.ToInt32(user.Lead_Generation_Priority)) + (Convert.ToInt32(user.Sales_Generation_Priority)) + (Convert.ToInt32(user.Traffic_Generation_Priority));


                            switch (bap)
                            {

                                case 3:
                                    double result32 = user.Budget1 / 2.666;
                                    ViewBag.traf32 = result32.ToString("0.00") + " " + user.Currency;
                                    break;
                                case 6:
                                    double result62 = user.Budget1 / 2.85;
                                    ViewBag.traf62 = result62.ToString("0.00") + " " + user.Currency;
                                    break;
                                case 10:
                                    double result12 = user.Budget1 / 3.33333;
                                    ViewBag.traf12 = result12.ToString("0.00") + " " + user.Currency;
                                    break;
                                default:
                                    ViewBag.BA_P1 = "Please check your inputs";
                                    break;
                            }
                        }


                        else
                        {

                            ViewBag.Traffic_Gen1 = "Search Engine Optimization (SEO), Content Marketing";

                            string[] tf1;
                            tf1 = new string[2] { "Search Engine Optimization (SEO)", "Content Marketing" };
                            ViewBag.tf_array1 = tf1[0];
                            ViewBag.tf_array2 = tf1[1];

                            double bap = (Convert.ToInt32(user.Brand_Awareness_Priority)) + (Convert.ToInt32(user.Lead_Generation_Priority)) + (Convert.ToInt32(user.Sales_Generation_Priority)) + (Convert.ToInt32(user.Traffic_Generation_Priority));

                            switch (bap)
                            {


                                case 3:
                                    double result32 = user.Budget1 / 2.666;

                                    ViewBag.trafs = result32 / 2 + " " + user.Currency;
                                    break;
                                case 6:
                                    double result62 = user.Budget1 / 2.85;

                                    ViewBag.trafs = result62 / 2 + " " + user.Currency;
                                    break;
                                case 10:
                                    double result12 = user.Budget1 / 3.33333;

                                    ViewBag.trafs = result12 / 2 + " " + user.Currency;
                                    break;
                                default:
                                    ViewBag.BA_P1 = "Please check your inputs";
                                    break;
                            }

                        }



                    }




                    if (user.Traffic_Generation != null && Convert.ToInt32(user.Traffic_Generation_Priority) == 3)

                    {


                        if (user.Traffic_Generation != null && user.Brand_Awareness != null)
                        {
                            ViewBag.Traffic_Gen = "Search Engine Optimization (SEO)";

                            double bap = (Convert.ToInt32(user.Brand_Awareness_Priority)) + (Convert.ToInt32(user.Lead_Generation_Priority)) + (Convert.ToInt32(user.Sales_Generation_Priority)) + (Convert.ToInt32(user.Traffic_Generation_Priority));


                            switch (bap)
                            {

                                case 6:
                                    double result63 = user.Budget1 / 5;
                                    ViewBag.traf63 = result63.ToString("0.00") + " " + user.Currency;
                                    break;
                                case 10:
                                    double result13 = user.Budget1 / 5;
                                    ViewBag.traf13 = result13.ToString("0.00") + " " + user.Currency;
                                    break;
                                default:
                                    ViewBag.BA_P1 = "Please check your inputs";
                                    break;
                            }
                        }


                        else
                        {

                            ViewBag.Traffic_Gen1 = "Search Engine Optimization (SEO), Content Marketing";

                            string[] tf1;
                            tf1 = new string[2] { "Search Engine Optimization (SEO)", "Content Marketing" };
                            ViewBag.tf_array1 = tf1[0];
                            ViewBag.tf_array2 = tf1[1];

                            double bap = (Convert.ToInt32(user.Brand_Awareness_Priority)) + (Convert.ToInt32(user.Lead_Generation_Priority)) + (Convert.ToInt32(user.Sales_Generation_Priority)) + (Convert.ToInt32(user.Traffic_Generation_Priority));

                            switch (bap)
                            {


                                case 6:
                                    double result63 = user.Budget1 / 5;

                                    ViewBag.trafs = result63 / 2 + " " + user.Currency;
                                    break;
                                case 10:
                                    double result13 = user.Budget1 / 5;

                                    ViewBag.trafs = result13 / 2 + " " + user.Currency;
                                    break;
                                default:
                                    ViewBag.BA_P1 = "Please check your inputs";
                                    break;
                            }

                        }


                    }



                        if (user.Traffic_Generation != null && Convert.ToInt32(user.Traffic_Generation_Priority) == 4)
                        {


                            if (user.Traffic_Generation != null && user.Brand_Awareness != null)
                            {
                                ViewBag.Traffic_Gen = "Search Engine Optimization (SEO)";

                                double bap = (Convert.ToInt32(user.Brand_Awareness_Priority)) + (Convert.ToInt32(user.Lead_Generation_Priority)) + (Convert.ToInt32(user.Sales_Generation_Priority)) + (Convert.ToInt32(user.Traffic_Generation_Priority));


                                switch (bap)
                                {

                                    case 10:
                                        double result14 = user.Budget1 / 10;
                                        ViewBag.traf14 = result14.ToString("0.00") + " " + user.Currency;
                                        break;
                                    default:
                                        ViewBag.BA_P1 = "Please check your inputs";
                                        break;
                                }
                            }


                            else
                            {

                                ViewBag.Traffic_Gen1 = "Search Engine Optimization (SEO), Content Marketing";

                                string[] tf1;
                                tf1 = new string[2] { "Search Engine Optimization (SEO)", "Content Marketing" };
                                ViewBag.tf_array1 = tf1[0];
                                ViewBag.tf_array2 = tf1[1];

                                double bap = (Convert.ToInt32(user.Brand_Awareness_Priority)) + (Convert.ToInt32(user.Lead_Generation_Priority)) + (Convert.ToInt32(user.Sales_Generation_Priority)) + (Convert.ToInt32(user.Traffic_Generation_Priority));

                                switch (bap)
                                {


                                    case 10:
                                        double result14 = user.Budget1 / 10;

                                        ViewBag.trafs = result14 / 2 + " " + user.Currency;
                                        break;
                                    default:
                                        ViewBag.BA_P1 = "Please check your inputs";
                                        break;
                                }

                            }



                            
                        }
                    return View(user);
                }
                
                else
                        {
                            TempData["Error"] = "Please set your company goals and their priorities correctly!";
                            return RedirectToAction("Index", "Survey");

                        }

 
            }


            return View();
        }
    }
}

