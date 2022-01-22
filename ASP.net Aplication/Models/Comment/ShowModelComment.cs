using ASP.net_Aplication.Models.Identity;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ASP.net_Aplication.Models.Comment {
    public class ShowModelComment {
        public ShowModelComment(DBModelComment model, String userID) {
            this.CommentID = model.CommentID;
            this.CommentText = model.CommentText;
            this.CreateDate = model.CreateDate;
            this.ImageID = model.ImageID;

            this.Author = new ShowModelAuthor(model.Author, userID);
        }

        public ShowModelComment() { }

        [HiddenInput]
        public String CommentID { get; set; }

        [HiddenInput]
        public String ImageID { get; set; }

        public String CommentText { get; set; }

        public DateTime CreateDate { get; set; }

        public ShowModelAuthor Author { get; set; }

        public String ReturnUrl { get; set; }
    }
}
