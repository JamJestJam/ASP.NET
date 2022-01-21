using System;
using System.Linq;

namespace ASP.net_Aplication.Models.Image.EFImageRep {
    public partial class EFImageRep : IImageRep {
        public void Delete(Int32 imageID) {
            db.Images.Remove(this.db.Images.FirstOrDefault(a => a.ImageID == imageID));

            db.SaveChanges();
        }
    }
}
