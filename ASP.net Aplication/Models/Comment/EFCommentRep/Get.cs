using ASP.net_Aplication.Extends;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ASP.net_Aplication.Models.Comment.EFCommentRep {
    public partial class EFCommentRep : ICommentRep {
        public ShowModelComment Get(String CommentID, String userID) {
            ShowModelComment entity = this.db.Comments
                .Include(a => a.Author)
                .Where(a => a.CommentID == CommentID)
                .Select(a => new ShowModelComment(a, userID))
                .FirstOrDefault();

            return entity;
        }
    }
}
