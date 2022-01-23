using System;
using System.Linq;

namespace ASP.net_Aplication.Models.Image.EFImageRep {
    public partial class EFImageRep : IImageRep {
        public DBModelImage Delete(String imageID) {
            var data = this.db.Images.FirstOrDefault(a => a.ImageID == imageID);

            db.Images.Remove(data);
            db.SaveChanges();

            return data;
        }
    }
}
