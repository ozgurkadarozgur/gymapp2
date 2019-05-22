using System.ComponentModel.DataAnnotations;
using GymApp.Models;


namespace GymApp.Areas.Home.ViewModels
{
    public class UserViewModel
    {
    
        [Required]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
    }
}