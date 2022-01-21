using ASP.net_Aplication.Models.Database;

namespace ASP.net_Aplication.Models.Comment.EFCommentRep {
    public partial class EFCommentRep : ICommentRep {
        private readonly DbConnect db;

        public EFCommentRep(DbConnect db) {
            this.db = db;
        }
    }
}
