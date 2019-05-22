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
    public class AuthController : Controller
    {

        private GymAppContext db;
        public AuthController(GymAppContext gymAppContext)
        {
            db = gymAppContext;
        }

        public IActionResult Index()
        {
            var admin = HttpContext.Session.GetObjectFromJson<User>("admin");
            if(admin == null) return View();
            else return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Login(AuthUserViewModel authUserViewModel)
        {
            if(ModelState.IsValid){
                var admin = db.User.Where(x => x.Email == authUserViewModel.Email && x.Password == authUserViewModel.Password && x.UserTypeId == 1).FirstOrDefault();
                if(admin == null){
                    return RedirectToAction("Index");
                }else{
                    HttpContext.Session.SetObjectAsJson("admin", admin);
                    return RedirectToAction("Index", "Home");
                }                
            }else return RedirectToAction("Index");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.SetObjectAsJson("admin", null);
            return RedirectToAction("Index", "Auth");
        }

    }
}