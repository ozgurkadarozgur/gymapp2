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
using Microsoft.AspNetCore.Http;

namespace GymApp.Areas.GymOwner.Controllers
{
    [Area("GymOwner")]
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            var gym_owner = HttpContext.Session.GetObjectFromJson<User>("gym_owner");
            if(gym_owner == null) return RedirectToAction("Index", "Auth");
            else return View();            
        }
    }
}