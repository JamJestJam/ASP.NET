using ASP.net_Aplication.Extends;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.net_Aplication.Models.Identity {
    public class ModelRegister {
        [Required]
        [RegularExpression("^[A-z][a-z]{2,19}$")]
        public String FirstName { get; set; }

        [Required]
        [RegularExpression("^[A-z][a-z]{2,19}$")]
        public String LastName { get; set; }

        [Required]
        [DateBeetween]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; } = DateTime.Now;
        
        [Required]
        public String UserName { get; set; }

        [Required]
        [EmailAddress]
        public String Email { get; set; }

        [Required]
        [UIHint("password")]
        public String Password1 { get; set; }

        [Required]
        [UIHint("password")]
        [Compare(nameof(Password1))]
        public String Password2 { get; set; }

        [Phone]
        [Required]
        public String PhoneNumber { get; set; }

        public String ReturnUrl { get; set; }
    }
}
