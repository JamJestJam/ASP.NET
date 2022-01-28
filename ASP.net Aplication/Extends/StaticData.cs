using ASP.net_Aplication.Models.Comment;
using ASP.net_Aplication.Models.Database;
using ASP.net_Aplication.Models.Identity;
using ASP.net_Aplication.Models.Image;
using ASP.net_Aplication.Models.Rate;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace ASP.net_Aplication.Extends {
    public static class StaticData {
        public static readonly String path = Directory.GetParent(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)).Parent.Parent.Parent.FullName;

        public static readonly IReadOnlyList<DBModelAccount> users = new List<DBModelAccount> {
            new DBModelAccountStorage() {
                UserName = "Marek",
                FirstName = "Marek",
                LastName = "Michura",
                Password = "zaq1@WSX",
                Email = "email@email.com",
                BirthDate = new DateTime(1998, 11, 25),
                Id = Guid.NewGuid().ToString()
            },
            new DBModelAccountStorage() {
                UserName = "Karola",
                FirstName = "Karola",
                LastName = "Nazwisko",
                Password = "zaq1@WSX",
                Email = "Karola@email.com",
                BirthDate = new DateTime(1990, 10, 12),
                Id = Guid.NewGuid().ToString()
            },
            new DBModelAccountStorage() {
                UserName = "Jaszczur",
                FirstName = "Jaszczur",
                LastName = "Nazwisko",
                Password = "zaq1@WSX",
                Email = "Jaszczur@email.com",
                BirthDate = new DateTime(2001, 01, 01),
                Id = Guid.NewGuid().ToString()
            },
            new DBModelAccountStorage() {
                UserName = "Admin",
                FirstName = "Admin",
                LastName = "Admin",
                Password = "zaq1@WSX",
                Email = "admin@email.com",
                BirthDate = new DateTime(1998, 11, 25),
                Id = Guid.NewGuid().ToString()
            },
            new DBModelAccountStorage() {
                UserName = "Admin2",
                FirstName = "Admin",
                LastName = "Admin",
                Password = "zaq1@WSX",
                Email = "admin2@email.com",
                BirthDate = new DateTime(1990, 10, 12),
                Id = Guid.NewGuid().ToString()
            }
        };

        public static readonly IReadOnlyDictionary<String, IdentityRole> roleID = new Dictionary<String, IdentityRole> {
            {
                Role.Admin,
                new IdentityRole() {
                    Name = Role.Admin,
                    NormalizedName = Role.Admin.ToUpper(),
                    Id= Guid.NewGuid().ToString(),
                    ConcurrencyStamp = "30b9ebd8-fd3b-4dad-9842-1bb58de97760"
                }
            },
            {
                Role.User,
                new IdentityRole() {
                    Name = Role.User,
                    NormalizedName = Role.User.ToUpper(),
                    Id= Guid.NewGuid().ToString(),
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
                ImageID = Guid.NewGuid().ToString(),
            },
            new DBModelImageStorage {
                AuthorID= users[3].Id,
                ImageName = "Image2.png",
                ImageTitle = "Image2.png",
                CreateDate = new DateTime(2019, 11, 24),
                ImageID = Guid.NewGuid().ToString(),
            },
            new DBModelImageStorage {
                AuthorID= users[4].Id,
                ImageName = "Image3.png",
                ImageTitle = "Image3.png",
                CreateDate = new DateTime(2018, 10, 23),
                ImageID = Guid.NewGuid().ToString(),
            },
        };

        public static readonly IReadOnlyList<DBModelComment> comments = new List<DBModelComment> {
            new DBModelComment {
                AuthorID = users[0].Id,
                CreateDate = DateTime.Now,
                ImageID = images[0].ImageID,
                CommentText = "Komentarz 1",
                CommentID = Guid.NewGuid().ToString(),
            },
            new DBModelComment {
                AuthorID = users[2].Id,
                CreateDate = DateTime.Now,
                ImageID = images[1].ImageID,
                CommentText = "Komentarz 2",
                CommentID = Guid.NewGuid().ToString(),
            },
            new DBModelComment {
                AuthorID = users[3].Id,
                CreateDate = DateTime.Now,
                ImageID = images[2].ImageID,
                CommentText = "Komentarz 3",
                CommentID = Guid.NewGuid().ToString(),
            },
            new DBModelComment {
                AuthorID = users[4].Id,
                CreateDate = DateTime.Now,
                ImageID = images[2].ImageID,
                CommentText = "Komentarz 4",
                CommentID = Guid.NewGuid().ToString(),
            },
            new DBModelComment {
                AuthorID = users[1].Id,
                CreateDate = DateTime.Now,
                ImageID = images[2].ImageID,
                CommentText = "Komentarz 5",
                CommentID = Guid.NewGuid().ToString(),
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
            context.SaveChanges();

            Console.WriteLine("siema");
        }
    }
}
