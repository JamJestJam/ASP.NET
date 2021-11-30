using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Aplikacja.Models
{
    public class Image
    {
        [Key]
        [Required]
        public int ImageID { get; set; }

        public int UserID { get; set; }

        [Required(ErrorMessage = "Musisz być zalogowany")]
        public User Autor;

        [Required(ErrorMessage = "Wymagane jest Zdj.")]
        [Column(TypeName = "varBinary(max)")]
        public byte[] ImageSRC { get; set; }

        public ICollection<Comment> Comments { get; set; }
        public ICollection<Rate> Rates { get; set; }


        internal static void ModelCreate(ModelBuilder builder)
        {
            builder.Entity<Image>()
                .HasOne(a => a.Autor)
                .WithMany(a => a.Images)
                .HasForeignKey(a => a.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Image>()
                .HasData(new Image()
                {
                    ImageID = 1,
                    UserID = 1,
                    ImageSRC = new Byte[20]
                });
            builder.Entity<Image>()
               .HasData(new Image()
               {
                   ImageID = 2,
                   UserID = 1,
                   ImageSRC = new Byte[20]
               });
            builder.Entity<Image>()
               .HasData(new Image()
               {
                   ImageID = 3,
                   UserID = 1,
                   ImageSRC = new Byte[20]
               });
        }
    }
}
