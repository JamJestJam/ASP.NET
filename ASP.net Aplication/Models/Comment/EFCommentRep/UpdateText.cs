using System.Linq;

namespace ASP.net_Aplication.Models.Comment.EFCommentRep {
    public partial class EFCommentRep : ICommentRep {
        public DBModelComment UpdateText(UpdateModelComment model) {
            DBModelComment entity = db.Comments.FirstOrDefault(a => a.CommentID == model.CommentID);
            entity.CommentText = model.CommentText;

            db.Comments.Update(entity);
            db.SaveChanges();

            return entity;
        }
    }
}
