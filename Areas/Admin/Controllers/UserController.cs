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
    public class UserController : Controller
    {
        private GymAppContext db;

        public UserController(GymAppContext gymAppContext)
        {
            db = gymAppContext;
        }

        public IActionResult Index()
        {                   
            var admin = HttpContext.Session.GetObjectFromJson<User>("admin");
            if(admin == null) return RedirectToAction("Index", "Auth");    
            var UserList = db.User.Include(x => x.UserType).ToList(); 
            return View(UserList);
        }

        public IActionResult Create()
        {                
            var admin = HttpContext.Session.GetObjectFromJson<User>("admin");
            if(admin == null) return RedirectToAction("Index", "Auth");     
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserViewModel userViewModel)
        {     
            var admin = HttpContext.Session.GetObjectFromJson<User>("admin");
            if(admin == null) return RedirectToAction("Index", "Auth");       
            if(ModelState.IsValid)
            {
                db.User.Add(
                        new User {
                            UserTypeId = userViewModel.UserTypeId,
                            Email = userViewModel.Email,
                            Username = userViewModel.Username,
                            FirstName = userViewModel.FirstName,
                            LastName = userViewModel.LastName,
                            Password = userViewModel.Password
                    }
                );
                db.SaveChanges();
                return RedirectToAction("Index");
            }            
            return View(userViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
