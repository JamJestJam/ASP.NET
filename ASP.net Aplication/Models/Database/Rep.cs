using ASP.net_Aplication.Models.Comment;
using ASP.net_Aplication.Models.Image;
using ASP.net_Aplication.Models.Rate;
using System.Linq;

namespace ASP.net_Aplication.Models.Database {
    public class Rep : IRep {
        private readonly DbConnect context;

        public IQueryable<DBModelImage> Images => context.Images;
        public IQueryable<DBModelRate> Rates => context.Rates;
        public IQueryable<DBModelComment> Comments => context.Comments;

        public Rep(DbConnect context) {
            this.context = context;
        }
    }
}
