using System.ComponentModel.DataAnnotations;
using GymApp.Models;
using GymApp.Areas.Admin.PropertyValidations;

namespace GymApp.Areas.Admin.ViewModels
{
    public class UserViewModel
    {

        [Required]
        public int UserTypeId { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [NotExistUserEmail]
        public string Email { get; set; }
    }
}