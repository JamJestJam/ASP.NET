using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ASP.net_Aplication.Models.Comment.EFCommentRep {
    public partial class EFCommentRep : ICommentRep {
        public ShowModelComment Get(Int32 id, String userID) {
            return this.db.Comments
                .Include(a => a.Author)
                .Where(a => a.CommentID == id)
                .Select(a => new ShowModelComment(a, userID))
                .FirstOrDefault();
        }
    }
}
