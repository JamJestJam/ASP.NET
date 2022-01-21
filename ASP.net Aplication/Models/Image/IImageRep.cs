using System;
using System.Collections.Generic;

namespace ASP.net_Aplication.Models.Image {
    public interface IImageRep {
        DBModelImage Add(DBModelImage image);

        IEnumerable<SchowModelImage> GetPage(Int32 page, String userID);

        SchowModelImage GetImage(Int32 id, String userID, Int32 page);

        UpdateModelImage GetImageUpdate(Int32 id, String userID);

        DBModelImage UpdateTitle(UpdateModelImage model);

        void Delete(Int32 imageID);

        Int32 CountPages();

        public static Int32 PerPage { get; set; }
    }
}
