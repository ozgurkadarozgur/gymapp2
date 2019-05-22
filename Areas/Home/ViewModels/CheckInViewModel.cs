using System.ComponentModel.DataAnnotations;
using GymApp.Areas.Home.PropertyValidations;

namespace GymApp.Areas.Home.ViewModels
{
    public class CheckInViewModel
    {
        [Required]
        public int GymId { get; set; }
    }
}