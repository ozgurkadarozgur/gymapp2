using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GymApp.Models;
using GymApp.Areas.Admin.ViewModels;
using Microsoft.EntityFrameworkCore;
using GymApp.Areas.GymOwner.ViewModels;
using GymApp.Helpers;

namespace GymApp.Areas.GymOwner.Controllers
{
    [Area("GymOwner")]
    public class ReservationController : Controller
    {
        private GymAppContext db;

        public ReservationController(GymAppContext gymAppContext)
        {
            db = gymAppContext;
        }

        public IActionResult Index()
        {
            var gym_owner = HttpContext.Session.GetObjectFromJson<User>("gym_owner");
            if(gym_owner == null) return RedirectToAction("Index", "Auth");            
            var reservationList = db.Reservation.Where(x => x.Gym.Owner.Id == gym_owner.Id).Include(x => x.User).Include(x => x.Gym).ToList();
            return View(reservationList);
        }

        public IActionResult CheckIn(int id)
        {
            var gym_owner = HttpContext.Session.GetObjectFromJson<User>("gym_owner");
            if(gym_owner == null) return RedirectToAction("Index", "Auth");
            Reservation reservation = db.Reservation.Where(x => x.Id == id)
                                    .Include(x => x.User)
                                    .FirstOrDefault();   

            CheckInViewModel checkInViewModel = new CheckInViewModel{
                Reservation = reservation                
            };                                             
            return View(checkInViewModel);
        }

        [HttpPost]
        public IActionResult CheckIn(CheckInViewModel checkInViewModel, int id)
        {
            var gym_owner = HttpContext.Session.GetObjectFromJson<User>("gym_owner");
            if(gym_owner == null) return RedirectToAction("Index", "Auth");
            var reservation = db.Reservation.Where(x => x.Id == id).FirstOrDefault();
            if(reservation.Code == checkInViewModel.Code && !reservation.didCheckIn())
            {
                CheckIn checkin = new CheckIn{ReservationId = id};
                db.CheckIn.Add(checkin);
                db.SaveChanges(); 
            }                      
            return RedirectToAction("Index");
        }

    }
}