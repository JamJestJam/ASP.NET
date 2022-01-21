using ASP.net_Aplication.Models.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace ASP.net_Aplication.Models.Comment {
    public class UpdateModelComment {
        [HiddenInput]
        [Required(ErrorMessage = "Wystąpił problem proszę poczekać")]
        public Int32 CommentID { get; set; }

        [Required(ErrorMessage = "Niepoprawna treść")]
        [MinLength(5, ErrorMessage = "Zbyt krótki komentarz")]
        public String CommentText { get; set; }

        [HiddenInput]
        public String ReturnUrl { get; set; }

        public ShowModelAuthor Author { get; set; }
    }
}
