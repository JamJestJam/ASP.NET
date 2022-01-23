using ASP.net_Aplication.Extends;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace ASP.net_Aplication.Models.Image {
    public class AddModelImage {
        [Display(Name = "Wybierz obrazek")]
        [Required(ErrorMessage = "Wymagane jest Zdj.")]
        [IsImage(ErrorMessage = "Wprowadzony plik nie jest zdjęciem")]
        public IFormFile ImageName { get; set; }

        [Display(Name = "Tytuł obrazka")]
        [Required(ErrorMessage = "Musisz podać tytuł")]
        [MinLength(5, ErrorMessage = "Zbyt krótka nazwa")]
        public String ImageTitle { get; set; }

        [HiddenInput]
        public String ReturnUrl { get; set; }
    }
}
