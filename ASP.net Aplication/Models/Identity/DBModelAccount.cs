using ASP.net_Aplication.Extends;
using ASP.net_Aplication.Models.Comment;
using ASP.net_Aplication.Models.Image;
using ASP.net_Aplication.Models.Rate;
using ExpressiveAnnotations.Attributes;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Security.Cryptography;

namespace ASP.net_Aplication.Models.Identity {
    public class DBModelAccount : IdentityUser {
        [Required]
        [PersonalData]
        public String FirstName { get; set; }

        [Required]
        [PersonalData]
        public String LastName { get; set; }

        [Required]
        [PersonalData]
        [DataType(DataType.Date)]
        [AssertThat("BirthDate <= Today()")]
        public DateTime BirthDate { get; set; }

        public IEnumerable<DBModelImage> Images;

        public IEnumerable<DBModelRate> Rates;

        public IEnumerable<DBModelComment> Comments;

        public static void ModelCreate(ModelBuilder builder) {
            builder.Entity<IdentityRole>().HasData(StaticData.roleID.Values);
            builder.Entity<DBModelAccount>().HasData(StaticData.users);
            builder.Entity<IdentityUserRole<String>>().HasData(StaticData.roles);
        }
    }

    public class DBModelAccountStorage {
        public String UserName { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Password { get; set; }
        public String Email { get; set; }
        public DateTime BirthDate { get; set; }
        public String Id { get; set; }

        public static implicit operator DBModelAccount(DBModelAccountStorage model) {
            PasswordHasher<DBModelAccount> passHash = new();
            DBModelAccount user = new() {
                Id = model.Id,
                UserName = model.UserName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                BirthDate = model.BirthDate,

                NormalizedUserName = model.UserName.ToUpper(),
                NormalizedEmail = model.Email.ToUpper(),
                SecurityStamp = new Guid().ToString("D"),
            };

            user.PasswordHash = passHash.HashPassword(user, model.Password);
            return user;
        }
    }
}
