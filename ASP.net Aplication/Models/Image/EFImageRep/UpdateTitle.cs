using System.Linq;

namespace ASP.net_Aplication.Models.Image.EFImageRep {
    public partial class EFImageRep : IImageRep {
        public DBModelImage UpdateTitle(UpdateModelImage model) {
            DBModelImage tmp = db.Images.FirstOrDefault(a => a.ImageID == model.ImageID);
            tmp.ImageTitle = model.ImageTitle;

            db.Images.Update(tmp);
            db.SaveChanges();

            return tmp;
        }
    }
}
