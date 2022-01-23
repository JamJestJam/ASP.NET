using ASP.net_Aplication.Models.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ASP.net_Aplication.Models.Comment {
    public class ShowModelComment {
        public ShowModelComment(DBModelComment model, String userID) {
            this.CommentID = model.CommentID;
            this.CommentText = model.CommentText;
            this.CreateDate = model.CreateDate;
            this.ImageID = model.ImageID;

            if(model.Author != null)
            this.Author = new ShowModelAuthor(model.Author, userID);
        }

        [JsonIgnore]
        [HiddenInput]
        public String ImageID { get; }
        [HiddenInput]
        public String CommentID { get; }
        public String CommentText { get; }
        public DateTime CreateDate { get; }
        public ShowModelAuthor Author { get; }

        [JsonIgnore]
        public String ReturnUrl { get; set; }
    }
}
