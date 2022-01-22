using System;

namespace ASP.net_Aplication.Models.Comment {
    public interface ICommentRep {
        public DBModelComment Add(DBModelComment model);

        public ShowModelComment Get(String commentID, String userID);

        public void Delete(String commentID);

        public Int32 Count(String imageID);

        public DBModelComment UpdateText(UpdateModelComment model);

        public UpdateModelComment GetCommentUpdate(String commentID, String userID);

        public static Int32 PerPage { get; set; }
    }
}
