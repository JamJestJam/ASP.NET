using System;
using System.Linq;

namespace ASP.net_Aplication.Models.Image.EFImageRep {
    public partial class EFImageRep : IImageRep {
        public Int32 CountPages() {
            return (Int32)Math.Ceiling((this.db.Images.Count() / (Single)IImageRep.PerPage) - 1);
        }
    }
}
