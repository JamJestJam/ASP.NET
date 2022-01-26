using System;
using System.IO;
using System.Threading.Tasks;

namespace ASP.net_Aplication.Models.Image.EFImageRep {
    public partial class EFImageRep : IImageRep {
        public async Task<DBModelImage> Add(AddModelImage model, String userID) {
            using MemoryStream ms = new();
            await model.ImageName.CopyToAsync(ms);

            DBModelImage entity = this.db.Images
                .Add(new DBModelImage() {
                    ImageTitle = model.ImageTitle,
                    ImageSRC = ms.ToArray(),
                    AuthorID = userID
                })
                .Entity;

            this.db.SaveChanges();
            return entity;
        }
    }
}
