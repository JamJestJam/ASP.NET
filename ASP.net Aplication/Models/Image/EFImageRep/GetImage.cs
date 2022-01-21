using ASP.net_Aplication.Models.Comment;
using ASP.net_Aplication.Models.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ASP.net_Aplication.Models.Image.EFImageRep {
    public partial class EFImageRep : IImageRep {
        public SchowModelImage GetImage(Int32 id, String userID, Int32 page) {
            return this.db.Images
                .Include(a => a.Author)
                .Include(a => a.Rates)
                .Include(a => a.Comments)
                .ThenInclude(b => b.Author)
                .Where(a => a.ImageID == id)
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

                    Author = new ShowModelAuthor(a.Author, userID),
                    Comments = a.Comments
                        .OrderBy(a => a.CreateDate)
                        .Skip(page * ICommentRep.PerPage)
                        .Take(ICommentRep.PerPage)
                        .Select(b => new ShowModelComment(b, userID))
                }).ToList()
                .FirstOrDefault();
            ;
        }
    }
}
