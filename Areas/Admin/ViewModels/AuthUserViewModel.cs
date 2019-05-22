using System.ComponentModel.DataAnnotations;
using GymApp.Models;
using GymApp.Areas.Admin.PropertyValidations;

namespace GymApp.Areas.Admin.ViewModels
{
    public class AuthUserViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}