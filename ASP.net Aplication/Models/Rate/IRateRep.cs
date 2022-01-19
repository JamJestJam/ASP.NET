using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.net_Aplication.Models.Rate {
    public interface IRateRep {
        public Task<DBModelRate> Like(Int32 imageID, String userID, Boolean like);
    }
}
