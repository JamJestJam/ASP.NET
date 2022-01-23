using System;
using System.Collections.Generic;

namespace ASP.net_Aplication.Models.Image {
    public interface IImageRep {
        DBModelImage Add(DBModelImage image);

        IEnumerable<ShowModelImage> GetPage(Int32 page, String userID);

        ShowModelImage GetImage(String imageID, String userID, Int32 page);

        UpdateModelImage GetImageUpdate(String imageID, String userID);

        DBModelImage UpdateTitle(UpdateModelImage model);

        DBModelImage Delete(String imageID);

        Int32 CountPages();

        public static Int32 PerPage { get; set; }
    }
}
