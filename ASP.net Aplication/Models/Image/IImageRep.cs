using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.net_Aplication.Models.Image {
    public interface IImageRep {
        DBModelImage Add(DBModelImage image);

        IEnumerable<SchowModelImage> GetPage(Int32 page, String userID);

        SchowModelImage GetImage(Int32 id, String userID);

        UpdateModelImage GetImageUpdate(Int32 id, String userID);

        DBModelImage UpdateTitle(UpdateModelImage model);

        void Delete(Int32 imageID);
    }
}
