using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GymApp.Models;
using GymApp.Areas.Admin.ViewModels;
using Microsoft.EntityFrameworkCore;
using GymApp.Helpers;

namespace GymApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GymController : Controller
    {

        private GymAppContext db;

        public GymController(GymAppContext gymAppContext)
        {
            db = gymAppContext;
        }

        public IActionResult Index()
        {
            var admin = HttpContext.Session.GetObjectFromJson<User>("admin");
            if(admin == null) return RedirectToAction("Index", "Auth");
            var gymList = db.Gym.Include(x => x.Owner).ToList();
            return View(gymList);
        }

        public IActionResult Create()
        {        
            var admin = HttpContext.Session.GetObjectFromJson<User>("admin");
            if(admin == null) return RedirectToAction("Index", "Auth");                
            return View();
        }

        [HttpPost]
        public IActionResult Create(GymViewModel gymViewModel)
        {
            var admin = HttpContext.Session.GetObjectFromJson<User>("admin");
            if(admin == null) return RedirectToAction("Index", "Auth");
            if(ModelState.IsValid)
            {
                db.Gym.Add(
                    new Gym {
                        OwnerId = gymViewModel.OwnerId,
                        Title = gymViewModel.Title
                    }
                );
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(gymViewModel);
        }

    }
}