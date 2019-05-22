using System.ComponentModel.DataAnnotations;
using GymApp.Models;

namespace GymApp.Areas.Admin.ViewModels
{
    public class GymViewModel
    {
        [Required]
        public int OwnerId { get; set; }
        [Required]
        public string Title { get; set; }
    }
}