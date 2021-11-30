using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Aplikacja.Models
{
    public class User
    {
        [Key]
        [HiddenInput]
        [Required(ErrorMessage = "Wymagane jest ID")]
        public int UserID { get; set; }
        [Required(ErrorMessage = "Wymagana jest nazwa użytkownika")]
        public string Login { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Wymagane jest hasło")]
        [RegularExpression("(?=^.{8,}$)(?=.*\\d)(?=.*[!@#$%^&*]+)(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$", ErrorMessage = "Wymagane jest silne hasło")]
        public string Password { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Wymagany jest email")]
        [RegularExpression(".+\\@.+\\.[a-z]{2,3}", ErrorMessage = "Niepoprawny email")]
        public string Email { get; set; }
        public DateTime BirthDate { get; set; } = DateTime.Now;

        public ICollection<Image> Images { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Rate> Rates { get; set; }

        internal static void ModelCreate(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasIndex(a => a.Login)
                .IsUnique(true);

            builder.Entity<User>()
                .HasIndex(a => a.Email)
                .IsUnique(true);

            builder.Entity<User>().HasData(
                new User()
                {
                    UserID = 1,
                    Login = "marek",
                    Password = "zaq1@WSX",
                    Email = "email@email.com",
                    BirthDate = new DateTime(1998,11,25)
                }, new User()
                {
                    UserID = 2,
                    Login = "Kotek",
                    Password = "zaq1@WSX",
                    Email = "kotek@kotek.com",
                    BirthDate = new DateTime(1990,10,12)
                }, new User()
                {
                    UserID = 3,
                    Login = "jaszczur",
                    Password = "zaq1@WSX",
                    Email = "jaszczur@zjadlkotka.com",
                    BirthDate = new DateTime(2001,01,01)
                }
            );
        }
    }

    public interface ICrudUserRepository
    {
        User Find(int id);
        User Add(User user);
        User Update(User user);
        User remove(int id);

        IList<User> GetAll();
        IList<User> GetPage(int Page, int perPage = 2);

        //User AddImages();
    }

    public class CrudUserRepository : ICrudUserRepository
    {
        private DB db;

        public CrudUserRepository(DB db)
        {
            this.db = db;
        }

        public User Add(User user)
        {
            User entity = db.Users.Add(user).Entity;
            db.SaveChanges();
            return entity;
        }

        public User Find(int id)
        {
            User entity = db.Users.FirstOrDefault(a => a.UserID == id);
            return entity;
        }

        public IList<User> GetAll()
        {
            List<User> entities = db.Users.ToList();
            return entities;
        }

        public IList<User> GetPage(int Page, int perPage = 2)
        {
            List<User> entities = db.Users.OrderBy(a => a.Login).Skip(Page * perPage).Take(perPage).ToList();
            return entities;
        }

        public User remove(int id)
        {
            User entity = db.Users.Remove(db.Users.FirstOrDefault(a => a.UserID == id)).Entity;
            db.SaveChanges();
            return entity;
        }

        public User Update(User user)
        {
            User entity = db.Users.Update(user).Entity;
            db.SaveChanges();
            return entity;
        }
    }
}
