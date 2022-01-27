using ASP.net_Aplication.Models.Comment;
using ASP.net_Aplication.Models.Database;
using ASP.net_Aplication.Models.Identity;
using ASP.net_Aplication.Models.Image;
using ASP.net_Aplication.Models.Rate;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace ASP.net_Aplication.Extends {
    public static class StaticData {
        public static readonly String path = Directory.GetParent(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)).Parent.Parent.FullName;

        public static readonly IReadOnlyList<DBModelAccount> users = new List<DBModelAccount> {
            new DBModelAccountStorage() {
                UserName = "Marek",
                FirstName = "Marek",
                LastName = "Michura",
                Password = "zaq1@WSX",
                Email = "email@email.com",
                BirthDate = new DateTime(1998, 11, 25),
                Id = "afb093f1-b21d-426a-b2e0-ecdff742b2af"
            },
            new DBModelAccountStorage() {
                UserName = "Karola",
                FirstName = "Karola",
                LastName = "Nazwisko",
                Password = "zaq1@WSX",
                Email = "Karola@email.com",
                BirthDate = new DateTime(1990, 10, 12),
                Id = "31a8387d-5e4d-4426-94cc-ecd0a7864f4e"
            },
            new DBModelAccountStorage() {
                UserName = "Jaszczur",
                FirstName = "Jaszczur",
                LastName = "Nazwisko",
                Password = "zaq1@WSX",
                Email = "Jaszczur@email.com",
                BirthDate = new DateTime(2001, 01, 01),
                Id = "b2ef884b-d7b2-4aa7-84ab-ea0415968210"
            },
            new DBModelAccountStorage() {
                UserName = "Admin",
                FirstName = "Admin",
                LastName = "Admin",
                Password = "zaq1@WSX",
                Email = "admin@email.com",
                BirthDate = new DateTime(1998, 11, 25),
                Id = "4dfad9aa-6017-4836-89df-aed82f655b2f"
            },
            new DBModelAccountStorage() {
                UserName = "Admin2",
                FirstName = "Admin",
                LastName = "Admin",
                Password = "zaq1@WSX",
                Email = "admin2@email.com",
                BirthDate = new DateTime(1990, 10, 12),
                Id = "fed48f78-abac-406e-ab17-c27a27e6bbfd"
            }
        };

        public static readonly IReadOnlyDictionary<String, IdentityRole> roleID = new Dictionary<String, IdentityRole> {
            {
                Role.Admin,
                new IdentityRole() {
                    Name = Role.Admin,
                    NormalizedName = Role.Admin.ToUpper(),
                    Id= "860a20f9-3768-4832-b334-4184a18c006c",
                    ConcurrencyStamp = "30b9ebd8-fd3b-4dad-9842-1bb58de97760"
                }
            },
            {
                Role.User,
                new IdentityRole() {
                    Name = Role.User,
                    NormalizedName = Role.User.ToUpper(),
                    Id= "8ef9c940-acc9-4603-b6d6-8f9fa6be2800",
                    ConcurrencyStamp = "101e8163-68f9-4f42-bca1-08133538ea5e"
                }
            }
        };

        public static readonly IReadOnlyList<IdentityUserRole<String>> roles = new List<IdentityUserRole<String>>() {
            new IdentityUserRole<String>() {
                RoleId = roleID[Role.Admin].Id,
                UserId = users[0].Id
            },
            new IdentityUserRole<String>() {
                RoleId = roleID[Role.Admin].Id,
                UserId = users[1].Id
            },
            new IdentityUserRole<String>() {
                RoleId = roleID[Role.Admin].Id,
                UserId = users[2].Id
            },
            new IdentityUserRole<String>() {
                RoleId = roleID[Role.Admin].Id,
                UserId = users[3].Id
            },
            new IdentityUserRole<String>() {
                RoleId = roleID[Role.Admin].Id,
                UserId = users[4].Id
            }
        };

        public static readonly IReadOnlyList<DBModelImage> images = new List<DBModelImage>{
            new DBModelImageStorage {
                AuthorID= users[3].Id,
                ImageName = "Image1.jpg",
                ImageTitle = "Image1.jpg",
                CreateDate = new DateTime(2020, 12, 25),
                ImageID = "cda493c5-f7d1-4968-a2df-0c2162240fa0",
            },
            new DBModelImageStorage {
                AuthorID= users[3].Id,
                ImageName = "Image2.png",
                ImageTitle = "Image2.png",
                CreateDate = new DateTime(2019, 11, 24),
                ImageID = "02783261-ca59-432a-affd-de35e5c2b7d1",
            },
            new DBModelImageStorage {
                AuthorID= users[4].Id,
                ImageName = "Image3.png",
                ImageTitle = "Image3.png",
                CreateDate = new DateTime(2018, 10, 23),
                ImageID = "1a7b0d03-caed-4de5-ab58-98769049c166",
            },
        };

        public static readonly IReadOnlyList<DBModelComment> comments = new List<DBModelComment> {
            new DBModelComment {
                AuthorID = users[0].Id,
                CreateDate = DateTime.Now,
                ImageID = images[0].ImageID,
                CommentText = "Komentarz 1",
                CommentID = "2234f04d-f176-401f-8d2a-66882e0c9770",
            },
            new DBModelComment {
                AuthorID = users[2].Id,
                CreateDate = DateTime.Now,
                ImageID = images[1].ImageID,
                CommentText = "Komentarz 2",
                CommentID = "0661026b-03d1-4e98-a84d-f4ceadcdb265",
            },
            new DBModelComment {
                AuthorID = users[3].Id,
                CreateDate = DateTime.Now,
                ImageID = images[2].ImageID,
                CommentText = "Komentarz 3",
                CommentID = "146be234-dc45-4f2f-80d1-d01c18e6c679",
            },
            new DBModelComment {
                AuthorID = users[4].Id,
                CreateDate = DateTime.Now,
                ImageID = images[2].ImageID,
                CommentText = "Komentarz 4",
                CommentID = "56f71278-7844-4dd9-9939-5f6e79887b0c",
            },
            new DBModelComment {
                AuthorID = users[1].Id,
                CreateDate = DateTime.Now,
                ImageID = images[2].ImageID,
                CommentText = "Komentarz 5",
                CommentID = "78bfce5e-83f6-4b30-ab45-eed81fea6679",
            }
        };

        public static readonly IReadOnlyList<DBModelRate> rates = new List<DBModelRate> {
            new DBModelRate {
                ImageID = images[0].ImageID,
                UserID = users[0].Id,
                RateValue = true,
            },
            new DBModelRate {
                ImageID = images[0].ImageID,
                UserID = users[1].Id,
                RateValue = true,
            },
            new DBModelRate {
                ImageID = images[0].ImageID,
                UserID = users[2].Id,
                RateValue = true,
            },
            new DBModelRate {
                ImageID = images[0].ImageID,
                UserID = users[3].Id,
                RateValue = false,
            },
            new DBModelRate {
                ImageID = images[0].ImageID,
                UserID = users[4].Id,
                RateValue = false,
            },
        };

        public static void SeedData(DbConnect context) {
            context.Users.AddRange(users);
            context.Roles.AddRange(roleID.Values);
            context.UserRoles.AddRange(roles);
            context.Images.AddRange(images);
            context.Comments.AddRange(comments);
            context.Rates.AddRange(rates);
        }
    }
}
