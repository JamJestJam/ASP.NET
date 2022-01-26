using System.Linq;

namespace ASP.net_Aplication.Models.Image.EFImageRep {
    public partial class EFImageRep : IImageRep {
        public DBModelImage UpdateTitle(UpdateModelImage model) {
            DBModelImage entity = db.Images.FirstOrDefault(a => a.ImageID == model.ImageID);
            entity.ImageTitle = model.ImageTitle;

            db.Images.Update(entity);
            db.SaveChanges();

            return entity;
        }
    }
}
