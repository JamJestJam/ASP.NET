using ASP.net_Aplication.Models.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace ASP.net_Aplication.Models.Image {
    public class UpdateModelImage {
        [HiddenInput]
        [Required(ErrorMessage = "Wystąpił problem proszę poczekać")]
        public String ImageID { get; set; }

        [Display(Name = "Tytuł obrazka")]
        [Required(ErrorMessage = "Musisz podać tytuł")]
        [MinLength(5, ErrorMessage = "Zbyt krótka nazwa")]
        public String ImageTitle { get; set; }

        [HiddenInput]
        public String ReturnUrl { get; set; }

        public ShowModelAuthor Author { get; set; }
    }
}
