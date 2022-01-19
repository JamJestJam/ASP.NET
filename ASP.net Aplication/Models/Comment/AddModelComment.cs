using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.net_Aplication.Models.Comment {
    public class AddModelComment {
        [Required]
        [HiddenInput]
        public Int32 ImageID { get; set; }

        [Required]
        [RegularExpression("^[A-z].*[.,!?]$", ErrorMessage = "Komentarz musisz rozpocząć dużą literą i zakończyć kropką")]
        public String CommentText { get; set; }
    }
}
