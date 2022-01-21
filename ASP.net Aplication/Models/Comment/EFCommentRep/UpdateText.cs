using System.Linq;

namespace ASP.net_Aplication.Models.Comment.EFCommentRep {
    public partial class EFCommentRep : ICommentRep {
        public DBModelComment UpdateText(UpdateModelComment model) {
            DBModelComment tmp = db.Comments.FirstOrDefault(a => a.CommentID == model.CommentID);
            tmp.CommentText = model.CommentText;

            db.Comments.Update(tmp);
            db.SaveChanges();

            return tmp;
        }
    }
}
