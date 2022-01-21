using System;
using System.ComponentModel.DataAnnotations;

namespace ASP.net_Aplication.Extends {
    public class DateBeetweenAttribute : ValidationAttribute {
        public DateBeetweenAttribute() {
            this.ErrorMessage = "Date invalid";
        }

        public DateTime Smaller { get; set; } = DateTime.Now;
        public DateTime Larger { get; set; } = DateTime.MinValue;

        protected override ValidationResult IsValid(Object value, ValidationContext validationContext) {
            try {
                DateTime time = (DateTime)value;

                if (time > this.Smaller)
                    return new ValidationResult(this.ErrorMessage);
                if (time < this.Larger)
                    return new ValidationResult(this.ErrorMessage);
            } catch {
                return new ValidationResult(this.ErrorMessage);
            }
            return ValidationResult.Success;
        }
    }
}
