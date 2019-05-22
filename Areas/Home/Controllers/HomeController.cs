using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GymApp.Models;
using GymApp.Areas.Home.ViewModels;
using Microsoft.EntityFrameworkCore;
using GymApp.Helpers;
using Microsoft.AspNetCore.Http;

namespace GymApp.Areas.Home.Controllers
{
    [Area("Home")]
    public class HomeController : Controller {

        private GymAppContext db;

        public HomeController(GymAppContext gymAppContext) {
            db = gymAppContext;
        }
        public IActionResult Index() {
            var gyms = db.Gym.ToList();
            ViewData["GymList"] = gyms;
            return View();
        }
    }
}