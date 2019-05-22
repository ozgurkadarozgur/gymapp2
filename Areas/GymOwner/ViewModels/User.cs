using System.ComponentModel.DataAnnotations;


namespace GymApp.Areas.GymOwner.ViewModels
{
    public class UserViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}