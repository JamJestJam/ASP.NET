using ASP.net_Aplication.Extends;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace ASP.net_Aplication.Models.Image {
    public class AddModelImage {
        [Required(ErrorMessage = "Wymagane jest Zdj.")]
        [IsImageAttribute(ErrorMessage = "Wprowadzony plik nie jest zdjęciem")]
        public IFormFile ImageName { get; set; }

        [MinLength(5, ErrorMessage = "Zbyt krótka nazwa")]
        [Required(ErrorMessage = "Musisz podać tytuł")]
        public String ImageTitle { get; set; }

        [HiddenInput]
        public String ReturnUrl { get; set; }
    }
}
