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

namespace GymApp.Areas.Home.Controllers
{
    [Area("Home")]
    public class AuthController : Controller
    {
        private GymAppContext db;

        public AuthController(GymAppContext gymAppContext) {
            db = gymAppContext;
        }

        public IActionResult Login() {
            
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserViewModel userViewModel)
         {
             if (ModelState.IsValid) {
                 var user = db.User.Where(x => x.Email == userViewModel.Email && x.Password == userViewModel.Password && x.UserTypeId == 3).FirstOrDefault();
                 if (user != null) {
                     SetSession(user);
                     return RedirectToAction("Index","Home");
                 }
                 Console.WriteLine("YALAAAN");

             }
            return View(userViewModel);
        }

        public void SetSession(User user) {
            HttpContext.Session.SetObjectAsJson("user", user);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.SetObjectAsJson("user", null);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult SignUp() {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(RegisterViewModel registerViewModel) {
            if (ModelState.IsValid) {
                var user = new User(registerViewModel);
                user.UserTypeId = 3;
                user.Username = "no need";

                db.User.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }
            return View(registerViewModel);
        }


    }
}