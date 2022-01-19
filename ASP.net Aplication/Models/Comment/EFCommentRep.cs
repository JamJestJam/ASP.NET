using ASP.net_Aplication.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.net_Aplication.Models.Comment {
    public class EFCommentRep : ICommentRep {
        private readonly Database.DbConnect db;

        public EFCommentRep(Database.DbConnect db) {
            this.db = db;
        }

        public DBModelComment Add(DBModelComment model) {
            db.Comments.Add(model);
            db.SaveChanges();

            return model;
        }
    }
}
