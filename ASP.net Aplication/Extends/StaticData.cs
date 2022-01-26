using ASP.net_Aplication.Models.Comment;
using ASP.net_Aplication.Models.Identity;
using ASP.net_Aplication.Models.Image;
using ASP.net_Aplication.Models.Rate;
using System;
using System.Collections.Generic;
using System.IO;

namespace ASP.net_Aplication.Extends {
    public static class StaticData {
        public static readonly string path = Directory.GetParent(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)).Parent.Parent.FullName;

        public static readonly IReadOnlyList<DBModelAccount> users = new List<DBModelAccount> {
            new DBModelAccount() {
                UserName = "Marek",
                FirstName = "Marek",
                LastName = "Michura",
                PasswordHash = "zaq1@WSX",
                Email = "email@email.com",
                BirthDate = new DateTime(1998, 11, 25),
                Id = "afb093f1-b21d-426a-b2e0-ecdff742b2af"
            },
            new DBModelAccount() {
                UserName = "Karola",
                FirstName = "Karola",
                LastName = "Nazwisko",
                PasswordHash = "zaq1@WSX",
                Email = "Karola@email.com",
                BirthDate = new DateTime(1990, 10, 12),
                Id = "31a8387d-5e4d-4426-94cc-ecd0a7864f4e"
            },
            new DBModelAccount() {
                UserName = "Jaszczur",
                FirstName = "Jaszczur",
                LastName = "Nazwisko",
                PasswordHash = "zaq1@WSX",
                Email = "Jaszczur@email.com",
                BirthDate = new DateTime(2001, 01, 01),
                Id = "b2ef884b-d7b2-4aa7-84ab-ea0415968210"
            }
        };

        public static readonly IReadOnlyList<DBModelAccount> admins = new List<DBModelAccount> {
            new DBModelAccount() {
                UserName = "Admin",
                FirstName = "Admin",
                LastName = "Admin",
                PasswordHash = "zaq1@WSX",
                Email = "admin@email.com",
                BirthDate = new DateTime(1998, 11, 25),
                Id = "4dfad9aa-6017-4836-89df-aed82f655b2f"
            },
            new DBModelAccount() {
                UserName = "Admin2",
                FirstName = "Admin",
                LastName = "Admin",
                PasswordHash = "zaq1@WSX",
                Email = "admin2@email.com",
                BirthDate = new DateTime(1990, 10, 12),
                Id = "fed48f78-abac-406e-ab17-c27a27e6bbfd"
            },
        };

        public static readonly IReadOnlyDictionary<String, String> roleID = new Dictionary<String, String> {
            { Role.Admin, "1aa3f668-93fc-4f58-bba8-b09906e6f4bf" },
            { Role.User, "c3cf9643-f160-4446-95a0-a56c2e3d0027" }
        };

        public static readonly IReadOnlyList<DBModelImage> images = new List<DBModelImage>{
            new DBModelImage {
                AuthorID= admins[0].Id,
                ImageTitle = "Image1.jpg",
                CreateDate = new DateTime(2020, 12, 25),
                ImageID = "cda493c5-f7d1-4968-a2df-0c2162240fa0",
            },
            new DBModelImage {
                AuthorID= admins[0].Id,
                ImageTitle = "Image2.png",
                CreateDate = new DateTime(2019, 11, 24),
                ImageID = "02783261-ca59-432a-affd-de35e5c2b7d1",
            },
            new DBModelImage {
                AuthorID= admins[1].Id,
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
                AuthorID = admins[0].Id,
                CreateDate = DateTime.Now,
                ImageID = images[2].ImageID,
                CommentText = "Komentarz 3",
                CommentID = "146be234-dc45-4f2f-80d1-d01c18e6c679",
            },
            new DBModelComment {
                AuthorID = admins[1].Id,
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
                UserID = admins[0].Id,
                RateValue = false,
            },
            new DBModelRate {
                ImageID = images[0].ImageID,
                UserID = admins[1].Id,
                RateValue = false,
            },
        };
    }
}
