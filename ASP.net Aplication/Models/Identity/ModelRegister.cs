using ASP.net_Aplication.Extends;
using System;
using System.ComponentModel.DataAnnotations;

namespace ASP.net_Aplication.Models.Identity {
    public class ModelRegister {
        [Required(ErrorMessage = "Musisz uzupełnić pole")]
        [RegularExpression("^[A-z][a-z]{2,19}$")]
        public String FirstName { get; set; }

        [Required(ErrorMessage = "Musisz uzupełnić pole")]
        [RegularExpression("^[A-z][a-z]{2,19}$")]
        public String LastName { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Musisz uzupełnić pole")]
        [DateBeetween(ErrorMessage = "niepoprawna data urodzenia")]
        public DateTime BirthDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Musisz uzupełnić pole")]
        public String UserName { get; set; }

        [Required(ErrorMessage = "Musisz uzupełnić pole")]
        [EmailAddress(ErrorMessage = "Niepoprawny Email")]
        public String Email { get; set; }

        [UIHint("password")]
        [Required(ErrorMessage = "Musisz uzupełnić pole")]
        public String Password1 { get; set; }

        [UIHint("password")]
        [Required(ErrorMessage = "Musisz uzupełnić pole")]
        [Compare(nameof(Password1), ErrorMessage = "Hasła nie są identyczne")]
        public String Password2 { get; set; }

        [Required(ErrorMessage = "Musisz uzupełnić pole")]
        [Phone(ErrorMessage = "Numer telefonu nie jest poprawny")]
        public String PhoneNumber { get; set; }

        public String ReturnUrl { get; set; }
    }
}
