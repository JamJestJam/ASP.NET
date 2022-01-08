using ASP.net_Aplication.Extends;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ASP.net_Aplication.Models {
    public class ModelImage {

        #region Data =======================================================================

        #region Key ========================================================================

        [Key]
        [HiddenInput]
        [DefaultValue(0)]
        public Int32 ImageID { get; set; }

        [HiddenInput]
        public String AuthorID { get; set; }

        #endregion

        [Required(ErrorMessage = "Musisz podać tytuł")]
        [MinLength(5)]
        public String ImageTitle { get; set; }

        [Column(TypeName = "varBinary(max)")]
        public Byte[] ImageSRC { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Wymagane jest podanie daty utworzenia")]
        public DateTime CreateDate { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Wymagane jest Zdj.")]
        [IsImage(ErrorMessage = "Wprowadzony plik nie jest zdjęciem")]
        public IFormFile ImageName { get; set; }

        #endregion

        public ModelAccount Author;

        public IEnumerable<ModelRate> Rates;

        public IEnumerable<ModelComment> Comments;

        public static void ModelCreate(ModelBuilder builder) {
            builder.Entity<ModelImage>()
                .HasOne(a => a.Author)
                .WithMany(a => a.Images)
                .HasForeignKey(a => a.AuthorID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ModelImage>()
                .Property(a => a.CreateDate)
                .HasDefaultValueSql("getdate()");
        }
    }

    public class ViewModelImage {
        public Int32 ImageID { get; set; }

        public String ImageTitle { get; set; }

        public Byte[] ImageSRC { get; set; }

        public DateTime CreateDate { get; set; }

        public Boolean RateExist { get; set; }

        public Boolean RateValue { get; set; }

        public Int32 CountComment { get; set; }

        public Int32 CountRateUp { get; set; }

        public Int32 CountRateDown { get; set; }
    }

    public interface IImageRep {
        ModelImage Add(ModelImage image);

        IEnumerable<ViewModelImage> GetPage(Int32 page, String userID);

        ModelImage GetImage(Int32 id);
    }

    public class EFImageRep : IImageRep {
        private readonly DB db;
        private static readonly Int32 perPage = 10;

        public EFImageRep(DB db) {
            this.db = db;
        }

        public ModelImage GetImage(Int32 id) {
            ModelImage tmp = this.db.Images
                .Include(a => a.Author)
                .Include(a => a.Rates)
                .Include(a => a.Comments)
                .ThenInclude(b => b.User)
                .Where(a=>a.ImageID == id)
                .FirstOrDefault();

            return tmp;
        }

        public ModelImage Add(ModelImage image) {
            ModelImage entity = this.db.Images.Add(image).Entity;
            this.db.SaveChanges();
            return entity;
        }

        public IEnumerable<ViewModelImage> GetPage(Int32 page, String userID = "") {
            IEnumerable<ViewModelImage> tmp = db.Images
                .Include(a => a.Rates)
                .Include(a => a.Comments)
                .OrderBy(a => a.CreateDate)
                .ToList()
                .GroupBy(a => new {
                    a.ImageID,
                    a.ImageSRC,
                    a.ImageTitle,
                    a.CreateDate
                })
                .Select(a => new ViewModelImage() {
                    ImageID = a.Key.ImageID,
                    ImageSRC = a.Key.ImageSRC,
                    ImageTitle = a.Key.ImageTitle,
                    CreateDate = a.Key.CreateDate,
                    CountComment = a.Select(b=>b.Comments.Count()).First(),
                    RateExist = a.Any(b => b.Rates.Any(c => c.UserID == userID)),
                    RateValue = a.Any(b => b.Rates.Any(c => c.UserID == userID && c.RateValue)),
                    CountRateUp = a.Select(b => b.Rates.Where(c => c.RateValue).Count()).First(),
                    CountRateDown = a.Select(b => b.Rates.Where(c => !c.RateValue).Count()).First(),
                })
                .Skip(page * perPage)
                .Take(perPage);

            return tmp;
        }
    }
}
