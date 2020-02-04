using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstMVCinCSharp.Controllers
{
    public class MyFirstController : Controller
    {
        // GET: MyFirst
        public /*ActionResult*/ string Index(string Id, string name)
        {
            //return View();
            //return $"Hello from my first MVC controller {Environment.NewLine}Id = {Id} Name = {Request.QueryString["Name"]}";
            return $"Hello from my first MVC controller {Environment.NewLine}Id = {Id} Name = {name}";
        }

        public ActionResult IndexView() //Action result is commented as it is bundled with other Views
        {
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
    }
}