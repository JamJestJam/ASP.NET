using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aplikacja.Models
{
    public class Comment
    {
        public int CommentID { get; set; }

        [HiddenInput]
        [DefaultValue(0)]
        [Required(ErrorMessage = "zły UserID")]
        public int UserID { get; set; }

        [HiddenInput]
        [Required(ErrorMessage = "zły ImageID")]
        [DefaultValue(0)]
        public int ImageID { get; set; }

        [MinLength(5)]
        [Required(ErrorMessage = "niepoprawna treść")]
        public string CommentText { get; set; }
    }
}
