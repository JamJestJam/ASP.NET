using System;

namespace ASP.net_Aplication.Models.Comment {
    public interface ICommentRep {
        public DBModelComment Add(DBModelComment model);

        public ShowModelComment Get(Int32 id, String userID);

        public void Delete(Int32 id);

        public Int32 Count(Int32 imageID);

        public DBModelComment UpdateText(UpdateModelComment model);

        public UpdateModelComment GetCommentUpdate(Int32 id, String userID);

        public static Int32 PerPage { get; set; }
    }
}
