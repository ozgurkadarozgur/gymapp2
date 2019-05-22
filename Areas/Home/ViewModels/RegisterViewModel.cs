using System.ComponentModel.DataAnnotations;
using GymApp.Areas.Home.PropertyValidations;

namespace GymApp.Areas.Home.ViewModels
{
    public class RegisterViewModel
    {
    
        [Required]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [NotExistUserEmail]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",ErrorMessage = "Lütfen geçerli bir telefon numarası giriniz.")]
        public string Phone { get; set; }
    }
}