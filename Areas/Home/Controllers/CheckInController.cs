using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GymApp.Areas.Home.ViewModels;
using GymApp.Models;
using GymApp.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace GymApp.Areas.Home.Controllers
{
    [Area("Home")]
    public class CheckInController : Controller
    {
        private GymAppContext db;

        public CheckInController(GymAppContext gymAppContext) {
            db = gymAppContext;
        }

        public IActionResult Index() 
        {
            var user = HttpContext.Session.GetObjectFromJson<User>("user");
            if(user == null) return RedirectToAction("Index", "Home");
            //ViewData["UserList"] = db.User.Where(x => x.UserTypeId == 3).ToList();
            ViewData["reservationList"] = db.Reservation.Where(x => x.UserId == user.Id).Include(x => x.Gym).OrderByDescending(x => x.Id).ToList();
            ViewData["GymList"] = db.Gym.ToList();    
            return View();
        }

        [HttpPost]
        public IActionResult Create(CheckInViewModel checkInViewModel) 
        {
            var user = HttpContext.Session.GetObjectFromJson<User>("user");
            if(user == null) return RedirectToAction("Index", "Home");
            //TODO: make checkin here
            //get current user from session
            //and do checkin operation

            Random rand = new Random();
            string code = rand.Next(100000, 999999).ToString();  
            db.Reservation.Add(
                new Reservation {
                    UserId = user.Id,
                    GymId = checkInViewModel.GymId,
                    Code = code
                }
            );
            db.SaveChanges();

            return RedirectToAction("Index", "CheckIn");
        }
    }

}