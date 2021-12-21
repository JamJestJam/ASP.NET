using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

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

    public interface ICrudImageRepository
    {
        Image Find(int id);
        Image Add(Image image);
        Image Update(Image image);
        Image remove(int id);

        IList<Image> GetAll();
        IList<Image> GetPage(int Page, int perPage = 2);

        Image GetFullImageInfo(int id);
    }

    public class CrudImageRepository : ICrudImageRepository
    {
        private DB db;

        public CrudImageRepository(DB db)
        {
            this.db = db;
        }

        public Image Add(Image image)
        {
            Image entity = db.Images.Add(image).Entity;
            db.SaveChanges();
            return entity;
        }

        public Image Find(int id)
        {
            Image entity = db.Images.FirstOrDefault(a => a.ImageID == id);
            return entity;
        }

        public IList<Image> GetAll()
        {
            List<Image> entities = db.Images.ToList();
            return entities;
        }

        public IList<Image> GetPage(int Page, int perPage = 2)
        {
            List<Image> entities = db.Images.OrderBy(a => a.ImageID).Skip(Page * perPage).Take(perPage).ToList();
            return entities;
        }

        public Image remove(int id)
        {
            Image entity = db.Images.Remove(db.Images.FirstOrDefault(a => a.ImageID == id)).Entity;
            db.SaveChanges();
            return entity;
        }

        public Image Update(Image image)
        {
            Image entity = db.Images.Update(image).Entity;
            db.SaveChanges();
            return entity;
        }

        public Image GetFullImageInfo(int id)
        {
            Image entity = db.Images
                .Include(a => a.Autor)
                .Include(a => a.Rates)
                .ThenInclude(a => a.Autor)
                .Include(a => a.Comments)
                .ThenInclude(a => a.Autor)
                .FirstOrDefault(a => a.ImageID == id);
            return entity;
        }
    }
}
