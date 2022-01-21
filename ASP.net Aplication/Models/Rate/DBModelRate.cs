using ASP.net_Aplication.Models.Identity;
using ASP.net_Aplication.Models.Image;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP.net_Aplication.Models.Rate {
    public class DBModelRate {
        [HiddenInput]
        [Required(ErrorMessage = "Wystąpił problem")]
        public Int32 ImageID { get; set; }

        [HiddenInput]
        [Required(ErrorMessage = "Musisz być zalogowany")]
        public String UserID { get; set; }

        [DefaultValue(false)]
        [Required(ErrorMessage = "Niepoprawna ocena")]
        public Boolean RateValue { get; set; }

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
