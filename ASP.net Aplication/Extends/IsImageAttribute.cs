using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System;

namespace ASP.net_Aplication.Extends {
    public class IsImageAttribute : ValidationAttribute {
        protected override ValidationResult IsValid(Object value, ValidationContext validationContext) {
            try {
                IFormFile file = (IFormFile)value;

                if (!file.IsImage()) {
                    return new ValidationResult(this.ErrorMessage);
                }
            } catch {
                return new ValidationResult(this.ErrorMessage);
            }
            return ValidationResult.Success;
        }
    }
}
