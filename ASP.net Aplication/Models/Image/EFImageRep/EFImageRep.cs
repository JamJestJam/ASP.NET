using ASP.net_Aplication.Models.Database;

namespace ASP.net_Aplication.Models.Image.EFImageRep {
    public partial class EFImageRep : IImageRep {
        private readonly DbConnect db;

        public EFImageRep(DbConnect db) {
            this.db = db;
        }
    }
}
