using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aplikacja.Models
{
    public class User
    {
        [HiddenInput]
        [Required(ErrorMessage = "Wymagane jest ID")]
        public int UserID { get; set; }
        [Required(ErrorMessage = "Wymagana jest nazwa użytkownika")]
        public string Login { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Wymagane jest hasło")]
        [RegularExpression("(?=^.{8,}$)(?=.*\\d)(?=.*[!@#$%^&*]+)(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$", ErrorMessage = "Wymagane jest silne hasło")]
        public string Password { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Wymagany jest email")]
        [RegularExpression(".+\\@.+\\.[a-z]{2,3}", ErrorMessage = "Niepoprawny email")]
        public string Email { get; set; }
        public DateTime BirthDate { get; set; } = DateTime.Now;
    }
}
