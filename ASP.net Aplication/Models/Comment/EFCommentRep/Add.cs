namespace ASP.net_Aplication.Models.Comment.EFCommentRep {
    public partial class EFCommentRep : ICommentRep {
        public DBModelComment Add(DBModelComment model) {
            DBModelComment entity = this.db.Comments.Add(model).Entity;
            this.db.SaveChanges();

            return entity;
        }
    }
}
