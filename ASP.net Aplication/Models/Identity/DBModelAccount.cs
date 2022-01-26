using ASP.net_Aplication.Extends;
using ASP.net_Aplication.Models.Comment;
using ASP.net_Aplication.Models.Image;
using ASP.net_Aplication.Models.Rate;
using ExpressiveAnnotations.Attributes;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

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
            static void AddUser(ModelBuilder builder, DBModelAccount entity, String roleID) {
                builder.Entity<DBModelAccount>().HasData(entity);
                builder.Entity<IdentityUserRole<String>>().HasData(
                    new IdentityUserRole<String> {
                        RoleId = roleID,
                        UserId = entity.Id
                    }
                );
            }

            foreach (FieldInfo p in typeof(Role).GetFields()) {
                String role = (String)p.GetValue(null);
                builder.Entity<IdentityRole>().HasData(new IdentityRole {
                    Id = StaticData.roleID[role],
                    Name = role
                });
            }

            foreach (DBModelAccount entity in StaticData.users) {
                AddUser(builder, entity, StaticData.roleID[Role.User]);
            }

            foreach (DBModelAccount entity in StaticData.admins) {
                AddUser(builder, entity, StaticData.roleID[Role.Admin]);
            }
        }
    }
}
