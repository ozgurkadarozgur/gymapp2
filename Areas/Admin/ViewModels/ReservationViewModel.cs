using System.ComponentModel.DataAnnotations;
using GymApp.Models;

namespace GymApp.Areas.Admin.ViewModels
{
    public class ReservationViewModel
    {    
        [Required]
        public int GymId { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}