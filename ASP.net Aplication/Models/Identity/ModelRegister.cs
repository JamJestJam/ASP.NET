using ASP.net_Aplication.Extends;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace ASP.net_Aplication.Models.Identity {
    public class ModelRegister {
        [Display(Name = "Imie")]
        [RegularExpression("^[A-z][a-z]{2,19}$")]
        [Required(ErrorMessage = "Musisz uzupełnić pole")]
        public String FirstName { get; set; }

        [Display(Name = "Nazwisko")]
        [RegularExpression("^[A-z][a-z]{2,19}$")]
        [Required(ErrorMessage = "Musisz uzupełnić pole")]
        public String LastName { get; set; }

        [Display(Name = "Data urodzenia")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Musisz uzupełnić pole")]
        [DateBeetween(ErrorMessage = "niepoprawna data urodzenia")]
        public DateTime BirthDate { get; set; } = DateTime.Now;

        [Display(Name = "Nazwa użytkownika")]
        [Required(ErrorMessage = "Musisz uzupełnić pole")]
        public String UserName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Musisz uzupełnić pole")]
        [EmailAddress(ErrorMessage = "Niepoprawny Email")]
        public String Email { get; set; }

        [Display(Name = "Hasło")]
        [UIHint("password")]
        [Required(ErrorMessage = "Musisz uzupełnić pole")]
        public String Password1 { get; set; }

        [UIHint("password")]
        [Display(Name = "Powtórz hasło")]
        [Required(ErrorMessage = "Musisz uzupełnić pole")]
        [Compare(nameof(Password1), ErrorMessage = "Hasła nie są identyczne")]
        public String Password2 { get; set; }

        [Display(Name = "Numer telefonu")]
        [Required(ErrorMessage = "Musisz uzupełnić pole")]
        [Phone(ErrorMessage = "Numer telefonu nie jest poprawny")]
        public String PhoneNumber { get; set; }

        [HiddenInput]
        public String ReturnUrl { get; set; }
    }
}
