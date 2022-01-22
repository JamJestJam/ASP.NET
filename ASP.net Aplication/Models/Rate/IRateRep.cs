using System;
using System.Threading.Tasks;

namespace ASP.net_Aplication.Models.Rate {
    public interface IRateRep {
        public Task<DBModelRate> Like(String imageID, String userID, Boolean like);
    }
}
