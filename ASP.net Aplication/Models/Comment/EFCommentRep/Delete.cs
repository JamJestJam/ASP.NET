using System;
using System.Linq;

namespace ASP.net_Aplication.Models.Comment.EFCommentRep {
    public partial class EFCommentRep : ICommentRep {
        public void Delete(String commentID) {
            db.Comments.Remove(this.db.Comments.FirstOrDefault(a => a.CommentID == commentID));

            db.SaveChanges();
        }

    }
}
