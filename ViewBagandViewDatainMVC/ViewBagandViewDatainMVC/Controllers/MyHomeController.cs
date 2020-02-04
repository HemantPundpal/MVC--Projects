using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ViewBagandViewDatainMVC.Controllers
{
    public class MyHomeController : Controller
    {
        // GET: MyHome
        public ActionResult IndexViewBag()
        {
            /* Note: ViewBag uses Dictionary name value internaly to store the data. */
            ViewBag.Countries = new List<string>()
            {
                "New Zealand",
                "India",
                "USA",
                "UK",
                "Canada"
            };
            return View();
        }

        public ActionResult IndexViewData()
        {
            ViewData["COUNTRIES"] = new List<string>()
            {
                "New Zealand",
                "India",
                "USA",
                "UK",
                "Canada"
            };
            return View();
        }
    }
}