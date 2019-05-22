using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GymApp.Models;
using Microsoft.EntityFrameworkCore;
using GymApp.Areas.Admin.ViewModels;
using GymApp.Helpers;

namespace GymApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReservationController : Controller
    {
        private GymAppContext db;

        public ReservationController(GymAppContext gymAppContext)
        {
            db = gymAppContext;
        }

        public IActionResult Index() {  
            var admin = HttpContext.Session.GetObjectFromJson<User>("admin");
            if(admin == null) return RedirectToAction("Index", "Auth");          
            var reservationList = db.Reservation.Include(x => x.Gym).Include(x => x.User).ToList();
            return View(reservationList);
        }

        public IActionResult Create() {
            var admin = HttpContext.Session.GetObjectFromJson<User>("admin");
            if(admin == null) return RedirectToAction("Index", "Auth");
            ViewData["UserList"] = db.User.Where(x => x.UserTypeId == 3).ToList();
            ViewData["GymList"] = db.Gym.ToList();        
            return View();
        }

        [HttpPost]
        public IActionResult Create(ReservationViewModel reservationViewModel) 
        {
            var admin = HttpContext.Session.GetObjectFromJson<User>("admin");
            if(admin == null) return RedirectToAction("Index", "Auth");
            Random rand = new Random();
            string code = rand.Next(100000,999999).ToString();  
            db.Reservation.Add(
                new Reservation {
                    UserId = reservationViewModel.UserId,
                    GymId = reservationViewModel.GymId,
                    Code = code
                }
            );
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Show(int id) {
            var admin = HttpContext.Session.GetObjectFromJson<User>("admin");
            if(admin == null) return RedirectToAction("Index", "Auth");
            var reservation = db.Reservation.Where(x => x.Id == id).FirstOrDefault();
            return View(reservation);
        }

        public IActionResult CheckIn(int id) {
            var admin = HttpContext.Session.GetObjectFromJson<User>("admin");
            if(admin == null) return RedirectToAction("Index", "Auth");
            var reservation = db.Reservation.Where(x => x.Id == id).FirstOrDefault();
            if(!reservation.didCheckIn(id) ) {
                CheckIn checkin = new CheckIn{ReservationId = id};
                db.CheckIn.Add(checkin);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

    }
}