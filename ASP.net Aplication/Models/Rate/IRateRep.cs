using System;

namespace ASP.net_Aplication.Models.Rate {
    public interface IRateRep {
        public DBModelRate Like(String imageID, String userID, Boolean like);
    }
}
