using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GymApp.Models;
using GymApp.Helpers;
using Microsoft.AspNetCore.Http;

namespace GymApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {

        private GymAppContext db;

        public HomeController(GymAppContext gymAppContext)
        {
            db = gymAppContext;
        }

        public IActionResult Index()
        {                        
            var admin = HttpContext.Session.GetObjectFromJson<User>("admin");
            if(admin == null) return RedirectToAction("Index", "Auth");
            var user = db.User.First();            
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
