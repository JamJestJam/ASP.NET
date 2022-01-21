using System;

namespace ASP.net_Aplication.Models.Identity {
    public class ShowModelAuthor {
        public ShowModelAuthor(DBModelAccount model, String userID) {
            this.FirstName = model.FirstName;
            this.LastName = model.LastName;
            this.ItsMe = model.Id == userID;
        }

        public ShowModelAuthor() { }

        public String FirstName { get; set; }

        public String LastName { get; set; }

        public Boolean ItsMe { get; set; }
    }
}
