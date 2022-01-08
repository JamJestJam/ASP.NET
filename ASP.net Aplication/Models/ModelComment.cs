using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace ASP.net_Aplication.Models {
    public class ModelComment {

        #region Data =======================================================================

        #region Key ========================================================================

        [Key]
        public Int32 CommentID { get; set; }

        [HiddenInput]
        [Required(ErrorMessage = "Wystąpił problem")]
        public Int32 ImageID { get; set; }

        [HiddenInput]
        public String UserID { get; set; }

        #endregion

        [MinLength(5)]
        [Required(ErrorMessage = "niepoprawna treść")]
        public String CommentText { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Wymagane jest podanie daty utworzenia")]
        public DateTime CreateDate { get; set; }

        #endregion

        public ModelAccount User;

        public ModelImage Image;

        public static void ModelCreate(ModelBuilder builder) {
            builder.Entity<ModelComment>()
                .HasOne(a => a.User)
                .WithMany(a => a.Comments)
                .HasForeignKey(a => a.UserID);

            builder.Entity<ModelComment>()
                .HasOne(a => a.Image)
                .WithMany(a => a.Comments)
                .HasForeignKey(a => a.ImageID);

            builder.Entity<ModelComment>()
                .Property(a => a.CreateDate)
                .HasDefaultValueSql("getdate()");
        }
    }

    public interface ICommentRep {
        public ModelComment Add(ModelComment model);
    }

    public class EFCommentRep : ICommentRep {
        private readonly DB db;

        public EFCommentRep(DB db) {
            this.db = db;
        }

        public ModelComment Add(ModelComment model) {
            db.Comments.Add(model);
            db.SaveChanges();

            return model;
        }
    }
}
