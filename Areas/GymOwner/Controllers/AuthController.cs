using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GymApp.Models;
using GymApp.Areas.GymOwner.ViewModels;
using Microsoft.EntityFrameworkCore;
using GymApp.Helpers;

namespace GymApp.Areas.GymOwner.Controllers
{
    [Area("GymOwner")]
    public class AuthController : Controller
    {

        private GymAppContext db;
        public AuthController(GymAppContext gymAppContext)
        {
            db = gymAppContext;
        }

        public IActionResult Index()
        {
            var gym_owner = HttpContext.Session.GetObjectFromJson<User>("gym_owner");
            if(gym_owner == null) return View();
            else return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Login(UserViewModel userViewModel)
        {
            if(ModelState.IsValid){
                var gym_owner = db.User.Where(x => x.Email == userViewModel.Email && x.Password == userViewModel.Password && x.UserTypeId == 2).FirstOrDefault();
                if(gym_owner == null){
                    return RedirectToAction("Index");
                }else{
                    HttpContext.Session.SetObjectAsJson("gym_owner", gym_owner);
                    return RedirectToAction("Index", "Home");
                }                
            }else return RedirectToAction("Index");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.SetObjectAsJson("gym_owner", null);
            return RedirectToAction("Index", "Auth");
        }

    }
}