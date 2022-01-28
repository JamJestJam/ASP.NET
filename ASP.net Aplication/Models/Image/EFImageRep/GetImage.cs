using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ASP.net_Aplication.Models.Image.EFImageRep {
    public partial class EFImageRep : IImageRep {
        public ShowModelImage GetImage(String imageID, String userID, Int32 page) {
            ShowModelImage entity = this.db.Images
                .Include(a => a.Author)
                .Include(a => a.Rates)
                .Include(a => a.Comments)
                    .ThenInclude(b => b.Author)
                .Where(a => a.ImageID == imageID)
                .Select(a => new ShowModelImage(a, userID, page))
                .ToList()
                .FirstOrDefault();

            return entity;
        }
    }
}
