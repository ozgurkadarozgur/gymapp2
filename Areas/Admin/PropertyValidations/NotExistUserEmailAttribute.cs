using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using GymApp.Models;
using System.Linq;
using GymApp.Areas.Admin.ViewModels;
using GymApp.Areas.Admin.Services;

namespace GymApp.Areas.Admin.PropertyValidations
{
    public class NotExistUserEmailAttribute : ValidationAttribute, IClientModelValidator
{
    public NotExistUserEmailAttribute()
    {
        
    }

        public void AddValidation(ClientModelValidationContext context)
        {            
            
            //throw new System.NotImplementedException();
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            UserViewModel userViewModel = (UserViewModel)validationContext.ObjectInstance;
            var db = (GymAppContext)validationContext.GetService(typeof(GymAppContext));
        
            if (db.User.Where(x => x.Email == userViewModel.Email).FirstOrDefault() != null)
            {
                return new ValidationResult("Email adresi başkası tarafından kullanılmaktadır.");
            }

            return ValidationResult.Success;
    }
}
}