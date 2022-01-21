namespace ASP.net_Aplication.Models.Image.EFImageRep {
    public partial class EFImageRep : IImageRep {
        public DBModelImage Add(DBModelImage image) {
            DBModelImage entity = this.db.Images.Add(image).Entity;
            this.db.SaveChanges();
            return entity;
        }
    }
}
