using ASP.net_Aplication.Models.Comment;
using ASP.net_Aplication.Models.Image;
using ASP.net_Aplication.Models.Rate;
using System.Linq;

namespace ASP.net_Aplication.Models.Database {
    public interface IRep {
        IQueryable<DBModelImage> Images { get; }
        IQueryable<DBModelRate> Rates { get; }
        IQueryable<DBModelComment> Comments { get; }
    }
}
