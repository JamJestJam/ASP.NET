using ASP.net_Aplication.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ASP.net_Aplication.Models.Image.EFImageRep {
    public partial class EFImageRep : IImageRep {
        public IEnumerable<SchowModelImage> GetPage(Int32 page, String userID = "") {
            IQueryable<SchowModelImage> tmp = db.Images
                .OrderByDescending(a => a.CreateDate)
                .Select(a => new SchowModelImage() {
                    ImageID = a.ImageID,
                    ImageSRC = a.ImageSRC,
                    CreateDate = a.CreateDate,
                    ImageTitle = a.ImageTitle,
                    CountComment = a.Comments.Count(),
                    CountRateUp = a.Rates.Count(b => b.RateValue),
                    CountRateDown = a.Rates.Count(b => !b.RateValue),
                    RateValueTrue = a.Rates.Any(c => c.UserID == userID && c.RateValue),
                    RateValueFalse = a.Rates.Any(c => c.UserID == userID && !c.RateValue),

                    Author = new ShowModelAuthor(a.Author, userID)
                })
                .Skip(page * IImageRep.PerPage)
                .Take(IImageRep.PerPage);

            return tmp;
        }
    }
}
