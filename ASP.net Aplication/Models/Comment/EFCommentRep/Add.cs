namespace ASP.net_Aplication.Models.Comment.EFCommentRep {
    public partial class EFCommentRep : ICommentRep {
        public DBModelComment Add(DBModelComment model) {
            this.db.Comments.Add(model);
            this.db.SaveChanges();

            return model;
        }
    }
}
