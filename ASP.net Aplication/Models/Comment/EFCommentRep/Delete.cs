using System;
using System.Linq;

namespace ASP.net_Aplication.Models.Comment.EFCommentRep {
    public partial class EFCommentRep : ICommentRep {
        public void Delete(Int32 id) {
            db.Comments.Remove(this.db.Comments.FirstOrDefault(a => a.CommentID == id));

            db.SaveChanges();
        }

    }
}
