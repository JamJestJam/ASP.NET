using ASP.net_Aplication.Models.Identity;
using ASP.net_Aplication.Models.Image;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.net_Aplication.Models.Rate {
    public class DBModelRate {

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

        public DBModelAccount User;

        public DBModelImage Image;

        public static void ModelCreate(ModelBuilder builder) {
            builder.Entity<DBModelRate>()
                .HasKey(a => new { a.UserID, a.ImageID });

            builder.Entity<DBModelRate>()
                .HasOne(a => a.User)
                .WithMany(a => a.Rates)
                .HasForeignKey(a => a.UserID);

            builder.Entity<DBModelRate>()
                .HasOne(a => a.Image)
                .WithMany(a => a.Rates)
                .HasForeignKey(a => a.ImageID);
        }
    }
}
