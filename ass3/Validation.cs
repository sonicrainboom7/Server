using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;

namespace ass3
{
    
    public class Validation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
            DateTime date = (DateTime)validationContext.ObjectInstance;
            if (date > DateTime.Now) {
                return new ValidationResult("Invalid DateTime");
            }
            return ValidationResult.Success;
        }
    }
}