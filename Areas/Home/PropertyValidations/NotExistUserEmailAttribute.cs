using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using GymApp.Models;
using System.Linq;
using GymApp.Areas.Home.ViewModels;


namespace GymApp.Areas.Home.PropertyValidations
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
        RegisterViewModel userViewModel = (RegisterViewModel)validationContext.ObjectInstance;
        var db = (GymAppContext)validationContext
                         .GetService(typeof(GymAppContext));
        
        if (db.User.Where(x => x.Email == userViewModel.Email).FirstOrDefault() != null)
        {
            return new ValidationResult("Bu E-mail adresiyle kayıt olunmuş. Önceden kayıt olmuş olabilir misin?");
        }

        return ValidationResult.Success;
    }
}
}