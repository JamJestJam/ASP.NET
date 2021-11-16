using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        [Key]
        [DefaultValue(0)]
        [Required(ErrorMessage = "Wymagany klucz główny")]
        public int CommentID { get; set; }

        //[DefaultValue(0)]
        //[Required(ErrorMessage = "zły UserID")]
        //public int ImageID;

        //[Required(ErrorMessage = "zły ImageID")]
        //[DefaultValue(0)]
        //public int UserID;

        [MinLength(5)]
        [Required(ErrorMessage = "niepoprawna treść")]
        public string CommentText { get; set; }

        //public Image Image { get; set; }

        //public User Autor { get; set; }

        internal static void ModelCreate(ModelBuilder builder)
        {
            //builder.Entity<Comment>()
            //    .HasOne(a => a.Autor)
            //    .WithMany(a => a.Comments)
            //    .HasForeignKey(a => a.UserID)
            //    .OnDelete(DeleteBehavior.Restrict);

            //builder.Entity<Comment>()
            //    .HasOne(a => a.Image)
            //    .WithMany(a => a.Comments)
            //    .HasForeignKey(a => a.ImageID)
            //    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
