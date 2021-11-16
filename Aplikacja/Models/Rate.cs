using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aplikacja.Models
{
    public class Rate
    {
        [Required]
        public int UserID { get; set; }
        [Required]
        public int ImageID { get; set; }

        //[Required]
        //public User Autor { get; set; }
        //[Required]
        //public Image Image { get; set; }

        [Key]
        [Range(0, 5, ErrorMessage = "Ocena spoza zakresu")]
        public int UserRate { get; set; }

        internal static void ModelCreate(ModelBuilder builder)
        {
            //builder.Entity<Rate>()
            //    .HasOne(a => a.Autor)
            //    .WithMany(a => a.Rates)
            //    .HasForeignKey(a => a.UserID)
            //    .OnDelete(DeleteBehavior.Restrict);

            //builder.Entity<Rate>()
            //    .HasOne(a => a.Image)
            //    .WithMany(a => a.Rates)
            //    .HasForeignKey(a => a.ImageID)
            //    .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Rate>()
                .HasKey(a => new { a.UserID, a.ImageID });
        }
    }
}
