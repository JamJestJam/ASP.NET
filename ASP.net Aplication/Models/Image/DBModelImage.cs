using ASP.net_Aplication.Extends;
using ASP.net_Aplication.Models.Comment;
using ASP.net_Aplication.Models.Identity;
using ASP.net_Aplication.Models.Rate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.net_Aplication.Models.Image {
    public class DBModelImage {
        [Key]
        public Int32 ImageID { get; set; }

        public String AuthorID { get; set; }

        [MinLength(5, ErrorMessage = "Zbyt krótka nazwa")]
        [Required(ErrorMessage = "Musisz podać tytuł")]
        public String ImageTitle { get; set; }

        [Column(TypeName = "varBinary(max)")]
        [Required(ErrorMessage = "Wymagane jest zdjęcie")]
        public Byte[] ImageSRC { get; set; }

        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Wymagane jest podanie daty utworzenia")]
        public DateTime CreateDate { get; set; } = DateTime.Now;

        public DBModelAccount Author;

        public IEnumerable<DBModelRate> Rates = new List<DBModelRate>();

        public IEnumerable<DBModelComment> Comments = new List<DBModelComment>();

        public static void ModelCreate(ModelBuilder builder) {
            builder.Entity<DBModelImage>()
                .HasOne(a => a.Author)
                .WithMany(a => a.Images)
                .HasForeignKey(a => a.AuthorID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DBModelImage>()
                .Property(a => a.CreateDate)
                .HasDefaultValueSql("getdate()");
        }
    }
}
