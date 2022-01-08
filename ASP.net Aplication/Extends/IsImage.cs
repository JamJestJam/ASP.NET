using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ASP.net_Aplication.Extends {
    public class IsImage : ValidationAttribute {
        public IsImage() { }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
            try {
                IFormFile file = ((IFormFile)value);

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
