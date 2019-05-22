using System.ComponentModel.DataAnnotations;
using GymApp.Models;

namespace GymApp.Areas.GymOwner.ViewModels
{
    public class CheckInViewModel
    {
        public Reservation Reservation { get; set; }
        [Required]
        public string Code { get; set; }
    }
}