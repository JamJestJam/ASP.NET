using ASP.net_Aplication.Models.Identity;
using System;
using System.Linq;

namespace ASP.net_Aplication.Models.Comment.EFCommentRep {
    public partial class EFCommentRep : ICommentRep {
        public UpdateModelComment GetCommentUpdate(Int32 id, String userID) {
            UpdateModelComment tmp = this.db.Comments
                .Where(a => a.CommentID == id)
                .Select(a => new UpdateModelComment() {
                    CommentID = a.CommentID,
                    CommentText = a.CommentText,
                    Author = new ShowModelAuthor(a.Author, userID)
                }).FirstOrDefault();

            return tmp;
        }
    }
}
