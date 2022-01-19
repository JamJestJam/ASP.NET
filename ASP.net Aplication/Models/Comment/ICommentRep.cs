using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.net_Aplication.Models.Comment {
    public interface ICommentRep {
        public DBModelComment Add(DBModelComment model);

    }
}
