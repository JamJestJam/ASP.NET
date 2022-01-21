using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace ASP.net_Aplication.Models.Identity {
    public class ModelLogin {
        [Required(ErrorMessage = "Login jest wymagany")]
        public String Login { get; set; }

        [UIHint("password")]
        [Required(ErrorMessage = "Hasło jest wymagane")]
        public String Password { get; set; }

        [HiddenInput]
        public String ReturnUrl { get; set; } = "/";
    }
}
