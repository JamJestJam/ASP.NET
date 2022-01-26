using ASP.net_Aplication.Models.Identity;
using System;
using System.Linq;

namespace ASP.net_Aplication.Models.Image.EFImageRep {
    public partial class EFImageRep : IImageRep {

        public UpdateModelImage GetImageUpdate(String ImageID, String userID) {
            UpdateModelImage entity = this.db.Images
                .Where(a => a.ImageID == ImageID)
                .Select(a => new UpdateModelImage() {
                    ImageID = a.ImageID,
                    ImageTitle = a.ImageTitle,
                    Author = new ShowModelAuthor(a.Author, userID)
                }).FirstOrDefault();

            return entity;
        }
    }
}
