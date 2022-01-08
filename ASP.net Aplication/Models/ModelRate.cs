using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace ASP.net_Aplication.Models {
    public class ModelRate {

        #region Data =======================================================================

        #region Key ========================================================================

        [HiddenInput]
        [Required(ErrorMessage = "Wystąpił problem")]
        public Int32 ImageID { get; set; }

        [HiddenInput]
        [Required(ErrorMessage = "Musisz być zalogowany")]
        public String UserID { get; set; }

        #endregion

        [Required(ErrorMessage = "Niepoprawna ocena")]
        [DefaultValue(false)]
        public Boolean RateValue { get; set; }

        #endregion

        public ModelAccount User;

        public ModelImage Image;

        public static void ModelCreate(ModelBuilder builder) {
            builder.Entity<ModelRate>()
                .HasKey(a => new { a.UserID, a.ImageID });

            builder.Entity<ModelRate>()
                .HasOne(a => a.User)
                .WithMany(a => a.Rates)
                .HasForeignKey(a => a.UserID);

            builder.Entity<ModelRate>()
                .HasOne(a => a.Image)
                .WithMany(a => a.Rates)
                .HasForeignKey(a => a.ImageID);
        }
    }

    public interface IRateRep {
        public Task<ModelRate> Like(Int32 imageID, String userID, Boolean like);
    }

    public class EFRateRep : IRateRep {
        private readonly DB db;

        public EFRateRep(DB db) {
            this.db = db;
        }

        public async Task<ModelRate> Like(Int32 imageID, String userID, Boolean like) {
            ModelRate prev = await this.db.Rates.FirstOrDefaultAsync(a => a.ImageID == imageID && a.UserID == userID);

            if (prev == null) {
                prev = new ModelRate() {
                    UserID = userID,
                    ImageID = imageID,
                    RateValue = like
                };
                db.Rates.Add(prev);
            } else {
                prev.RateValue = like;
                db.Rates.Update(prev);
            }
            db.SaveChanges();
            return prev;
        }
    }
}