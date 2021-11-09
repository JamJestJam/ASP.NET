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
        public int ImageID { get; set; }

        [Required(ErrorMessage = "Musisz być zalogowany")]
        public User Autor;

        [Required(ErrorMessage = "Wymagane jest Zdj.")]
        [Column(TypeName = "varBinary(max)")]
        public byte[] ImageSRC;

        public ICollection<Comment> Comments { get; set; }

        internal static void ModelCreate(ModelBuilder builder)
        {
            builder.Entity<Image>()
                .HasOne(a => a.Autor)
                .WithMany(a => a.Images);
        }
    }
}
