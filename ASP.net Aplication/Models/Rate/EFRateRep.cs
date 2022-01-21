using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ASP.net_Aplication.Models.Rate {
    public class EFRateRep : IRateRep {
        private readonly Database.DbConnect db;

        public EFRateRep(Database.DbConnect db) {
            this.db = db;
        }

        public async Task<DBModelRate> Like(Int32 imageID, String userID, Boolean like) {
            DBModelRate prev = await this.db.Rates.FirstOrDefaultAsync(a => a.ImageID == imageID && a.UserID == userID);

            if (prev == null) {
                prev = new DBModelRate() {
                    UserID = userID,
                    ImageID = imageID,
                    RateValue = like
                };
                db.Rates.Add(prev);
            } else {
                prev.RateValue = like;
                db.Rates.Update(prev);
            }
            db.SaveChanges();
            return prev;
        }
    }
}
