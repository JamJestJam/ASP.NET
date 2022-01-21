using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace ASP.net_Aplication.Models.Comment {
    public class AddModelComment {
        [Required]
        [HiddenInput]
        public Int32 ImageID { get; set; }

        [Required(ErrorMessage = "Musisz napisać komentarz")]
        [RegularExpression("^[A-z].*$", ErrorMessage = "Komentarz musisz rozpocząć dużą literą i zakończyć kropką")]
        public String CommentText { get; set; }
    }
}
