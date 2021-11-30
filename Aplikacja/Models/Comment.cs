using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aplikacja.Models
{
    public class Comment
    {
        [Key]
        [DefaultValue(0)]
        [Required(ErrorMessage = "Wymagany klucz główny")]
        public int CommentID { get; set; }

        [DefaultValue(0)]
        [Required(ErrorMessage = "zły UserID")]
        public int ImageID;

        [Required(ErrorMessage = "zły ImageID")]
        [DefaultValue(0)]
        public int UserID;

        [MinLength(5)]
        [Required(ErrorMessage = "niepoprawna treść")]
        public string CommentText { get; set; }

        public Image Image { get; set; }

        public User Autor { get; set; }

        internal static void ModelCreate(ModelBuilder builder)
        {
            builder.Entity<Comment>()
                .HasOne(a => a.Autor)
                .WithMany(a => a.Comments)
                .HasForeignKey(a => a.UserID);

            builder.Entity<Comment>()
                .HasOne(a => a.Image)
                .WithMany(a => a.Comments)
                .HasForeignKey(a => a.ImageID);

            builder.Entity<Comment>().HasData(new Comment()
            {
                CommentID = 1,
                UserID = 1,
                ImageID = 1,
                CommentText = "moje pierwsze wyssłane zdj."
            },
            new Comment()
            {
                CommentID = 2,
                UserID = 2,
                ImageID = 1,
                CommentText = "Coś ty stworzył"
            });
        }
    }

    public interface ICrudCommentRepository
    {
        Comment Find(int id);
        Comment Add(Comment comment);
        Comment Update(Comment comment);
        Comment remove(int id);

        IList<Comment> GetAll();
        IList<Comment> GetPage(int Page, int perPage = 2);
    }

    public class CrudCommentRepository : ICrudCommentRepository
    {
        private DB db;

        public CrudCommentRepository(DB db)
        {
            this.db = db;
        }

        public Comment Add(Comment comment)
        {
            Comment entity = db.Comments.Add(comment).Entity;
            db.SaveChanges();
            return entity;
        }

        public Comment Find(int id)
        {
            Comment entity = db.Comments.FirstOrDefault(a => a.CommentID == id);
            return entity;
        }

        public IList<Comment> GetAll()
        {
            List<Comment> entities = db.Comments.ToList();
            return entities;
        }

        public IList<Comment> GetPage(int Page, int perPage = 2)
        {
            List<Comment> entities = db.Comments.OrderBy(a => a.CommentID).Skip(Page * perPage).Take(perPage).ToList();
            return entities;
        }

        public Comment remove(int id)
        {
            Comment entity = db.Comments.Remove(db.Comments.FirstOrDefault(a => a.CommentID == id)).Entity;
            db.SaveChanges();
            return entity;
        }

        public Comment Update(Comment comment)
        {
            Comment entity = db.Comments.Update(comment).Entity;
            db.SaveChanges();
            return entity;
        }
    }
}
