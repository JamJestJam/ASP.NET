using ASP.net_Aplication.Models.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.net_Aplication.Models.Image {
    public class UpdateModelImage {
        [HiddenInput]
        [Required(ErrorMessage = "Wystąpił problem proszę poczekać")]
        public Int32 ImageID { get; set; }

        [MinLength(5, ErrorMessage = "Zbyt krótka nazwa")]
        [Required(ErrorMessage = "Musisz podać tytuł")]
        public String ImageTitle { get; set; }

        [HiddenInput]
        public String ReturnUrl { get; set; }

        public ShowModelAuthor Author { get; set; }
    }
}
