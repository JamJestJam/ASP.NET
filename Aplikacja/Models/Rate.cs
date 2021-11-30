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

        [Required]
        public User Autor { get; set; }
        [Required]
        public Image Image { get; set; }

        [Key]
        [Range(0, 5, ErrorMessage = "Ocena spoza zakresu")]
        public int UserRate { get; set; }

        internal static void ModelCreate(ModelBuilder builder)
        {
            builder.Entity<Rate>()
                .HasOne(a => a.Autor)
                .WithMany(a => a.Rates)
                .HasForeignKey(a => a.UserID);

            builder.Entity<Rate>()
                .HasOne(a => a.Image)
                .WithMany(a => a.Rates)
                .HasForeignKey(a => a.ImageID);

            builder.Entity<Rate>()
                .HasKey(a => new { a.UserID, a.ImageID });

            builder.Entity<Rate>()
                .HasData(
                    new Rate()
                    {
                        ImageID = 1,
                        UserID = 2,
                        UserRate = 5
                    }, new Rate()
                    {
                        ImageID = 1,
                        UserID = 3,
                        UserRate = 3
                    }
                );
        }
    }

    public interface ICrudRateRepository
    {
        Rate Find(int userID, int ImageID);
        Rate Add(Rate rate);
        Rate Update(Rate rate);
        Rate remove(int userID, int ImageID);

        IList<Rate> GetAll();
        IList<Rate> GetPage(int Page, int perPage = 2);
    }

    public class CrudRateRepository : ICrudRateRepository
    {
        private DB db;

        public CrudRateRepository(DB db)
        {
            this.db = db;
        }

        public Rate Add(Rate rate)
        {
            Rate entity = db.Rates.Add(rate).Entity;
            db.SaveChanges();
            return entity;
        }

        public Rate Find(int userID, int ImageID)
        {
            Rate entity = db.Rates.FirstOrDefault(a => a.ImageID == ImageID && a.UserID == userID);
            return entity;
        }

        public IList<Rate> GetAll()
        {
            List<Rate> entities = db.Rates.ToList();
            return entities;
        }

        public IList<Rate> GetPage(int Page, int perPage = 2)
        {
            List<Rate> entities = db.Rates.OrderBy(a => a.UserID).OrderBy(a => a.ImageID).Skip(Page * perPage).Take(perPage).ToList();
            return entities;
        }

        public Rate remove(int userID, int ImageID)
        {
            Rate entity = db.Rates.Remove(db.Rates.FirstOrDefault(a => a.ImageID == ImageID && a.UserID == userID)).Entity;
            db.SaveChanges();
            return entity;
        }

        public Rate Update(Rate rate)
        {
            Rate entity = db.Rates.Update(rate).Entity;
            db.SaveChanges();
            return entity;
        }
    }
}
