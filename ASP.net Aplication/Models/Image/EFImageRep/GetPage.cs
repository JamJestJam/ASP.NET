using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ASP.net_Aplication.Models.Image.EFImageRep {
    public partial class EFImageRep : IImageRep {
        public IEnumerable<ShowModelImage> GetPage(Int32 page, String userID = "") {
            IQueryable<ShowModelImage> entity = db.Images
                .Include(a => a.Author)
                .Include(a => a.Rates)
                .Include(a => a.Comments)
                .OrderByDescending(a => a.CreateDate)
                .Select(a => new ShowModelImage(a, userID))
                .Skip(page * IImageRep.PerPage)
                .Take(IImageRep.PerPage);

            return entity;
        }
    }
}
