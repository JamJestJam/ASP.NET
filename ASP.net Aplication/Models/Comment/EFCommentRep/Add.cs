using System;

namespace ASP.net_Aplication.Models.Comment.EFCommentRep {
    public partial class EFCommentRep : ICommentRep {
        public DBModelComment Add(AddModelComment model, String autorID) {
            DBModelComment newEntity = new() {
                AuthorID = autorID,
                CommentID = new Guid().ToString(),
                CreateDate = DateTime.Now,
                ImageID = model.ImageID,
                CommentText = model.CommentText
            };

            DBModelComment entity = this.db.Comments.Add(newEntity).Entity;
            this.db.SaveChanges();

            return entity;
        }
    }
}
