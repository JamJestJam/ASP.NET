using ASP.net_Aplication.Models.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.net_Aplication.Models.Image.EFImageRep {
    public partial class EFImageRep : IImageRep {
        public UpdateModelImage GetImageUpdate(Int32 id, String userID) {
            UpdateModelImage tmp = this.db.Images
                .Where(a => a.ImageID == id)
                .Select(a => new UpdateModelImage() {
                    ImageID = a.ImageID,
                    ImageTitle = a.ImageTitle,
                    Author = new ShowModelAuthor(a.Author, userID)
                }).FirstOrDefault();

            return tmp;
        }
    }
}
