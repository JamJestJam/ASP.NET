using System;
using System.Linq;

namespace ASP.net_Aplication.Models.Comment.EFCommentRep {
    public partial class EFCommentRep : ICommentRep {
        public Int32 Count(Int32 imageID) {
            return (Int32)Math.Ceiling(
                (this.db
                .Comments
                .Where(a => a.ImageID == imageID)
                .Count() / (Single)ICommentRep.PerPage) - 1);
        }
    }
}
