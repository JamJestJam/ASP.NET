using ASP.net_Aplication.Extends;
using ASP.net_Aplication.Models.Comment;
using ASP.net_Aplication.Models.Identity;
using ASP.net_Aplication.Models.Rate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

namespace ASP.net_Aplication.Models.Image {
    public class DBModelImage {
        [Key]
        public String ImageID { get; set; }

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
                .Property(a => a.ImageID)
                .HasDefaultValueSql("NEWID()");

            builder.Entity<DBModelImage>()
                .HasData(StaticData.images);

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

    public class DBModelImageStorage {
        public String ImageID { get; set; }
        public String AuthorID { get; set; }
        public String ImageTitle { get; set; }
        public String ImageName { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;

        public static implicit operator DBModelImage(DBModelImageStorage model) {
            String path = Path.Combine(StaticData.path, $"wwwroot\\firstImg\\{model.ImageName}");
            return new DBModelImage() {
                ImageID = model.ImageID,
                AuthorID = model.AuthorID,
                ImageTitle = model.ImageTitle,
                CreateDate = model.CreateDate,
                ImageSRC = File.ReadAllBytes(path)
            };
        }
    }
}
