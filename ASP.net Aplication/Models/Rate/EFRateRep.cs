using ASP.net_Aplication.Models.Database;
using System;
using System.Linq;

namespace ASP.net_Aplication.Models.Rate {
    public class EFRateRep : IRateRep {
        private readonly DbConnect db;

        public EFRateRep(DbConnect db) {
            this.db = db;
        }

        public DBModelRate Like(String imageID, String userID, Boolean like) {
            DBModelRate entity = this.db.Rates.FirstOrDefault(a => a.ImageID == imageID && a.UserID == userID);

            if (entity == null) {
                entity = new DBModelRate() {
                    UserID = userID,
                    ImageID = imageID,
                    RateValue = like
                };
                db.Rates.Add(entity);
            } else {
                entity.RateValue = like;
                db.Rates.Update(entity);
            }
            db.SaveChanges();
            return entity;
        }
    }
}
