using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aplikacja.Models
{
    public class User
    {
        [Required(ErrorMessage = "Wymagane jest ID")]
        public int ID { get; set; }
        [Required(ErrorMessage = "Wymagana jest nazwa użytkownika")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Wymagane jest hasło")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Wymagany jest email")]
        [RegularExpression(".+\\@.+\\.[a-z]{2,3}", ErrorMessage = "Niepoprawny email")]
        public string Email { get; set; }
        public DateTime BirthDate { get; set; } = DateTime.Now;
    }
}
