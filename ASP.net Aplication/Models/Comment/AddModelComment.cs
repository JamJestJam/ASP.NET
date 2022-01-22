using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace ASP.net_Aplication.Models.Comment {
    public class AddModelComment {
        [Required]
        [HiddenInput]
        public String ImageID { get; set; }

        [Display(Name = "Treść")]
        [Required(ErrorMessage = "Musisz napisać komentarz")]
        [RegularExpression("^[A-z].*$", ErrorMessage = "Komentarz musisz rozpocząć dużą literą i zakończyć kropką")]
        public String CommentText { get; set; }
    }
}
