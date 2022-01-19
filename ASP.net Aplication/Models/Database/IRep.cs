using ASP.net_Aplication.Models.Comment;
using ASP.net_Aplication.Models.Image;
using ASP.net_Aplication.Models.Rate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.net_Aplication.Models.Database {
    public interface IRep {
        IQueryable<DBModelImage> Images { get; }
        IQueryable<DBModelRate> Rates { get; }
        IQueryable<DBModelComment> Comments { get; }
    }
}
