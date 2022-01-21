using ASP.net_Aplication.Models.Identity;
using ASP.net_Aplication.Models.Image;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.net_Aplication.Models.Comment {
    public class DBModelComment {
        [Key]
        public Int32 CommentID { get; set; }

        [Required(ErrorMessage = "Wystąpił problem")]
        public Int32 ImageID { get; set; }

        [Column("UserID")]
        public String AuthorID { get; set; }

        [Required(ErrorMessage = "Niepoprawna treść")]
        [MinLength(5, ErrorMessage = "Zbyt krótki komentarz")]
        public String CommentText { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Wymagane jest podanie daty utworzenia")]
        public DateTime CreateDate { get; set; } = DateTime.Now;

        public DBModelAccount Author;

        public DBModelImage Image;

        public static void ModelCreate(ModelBuilder builder) {
            builder.Entity<DBModelComment>()
                .HasOne(a => a.Author)
                .WithMany(a => a.Comments)
                .HasForeignKey(a => a.AuthorID);

            builder.Entity<DBModelComment>()
                .HasOne(a => a.Image)
                .WithMany(a => a.Comments)
                .HasForeignKey(a => a.ImageID);

            builder.Entity<DBModelComment>()
                .Property(a => a.CreateDate)
                .HasDefaultValueSql("getdate()");
        }
    }
}
