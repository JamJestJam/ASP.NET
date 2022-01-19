using ASP.net_Aplication.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.net_Aplication.Models.Comment {
    public class ShowModelComment {
        public ShowModelComment(DBModelComment model, String userID) {
            this.CommentID = model.CommentID;
            this.CommentText = model.CommentText;
            this.CreateDate = model.CreateDate;
            this.Author = new ShowModelAuthor(model.Author, userID);
        }

        public Int32 CommentID { get; set; }

        public String CommentText { get; set; }

        public DateTime CreateDate { get; set; }

        public ShowModelAuthor Author { get; set; }
    }
}
