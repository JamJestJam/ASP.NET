using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ASP.net_Aplication.Models.Identity {
    public class ShowModelAuthor {
        public ShowModelAuthor(DBModelAccount model, String userID) {
            this.FirstName = model.FirstName;
            this.LastName = model.LastName;
            this.ItsMe = model.Id == userID;
        }
        public String FirstName { get; }
        public String LastName { get; }
        [JsonIgnore]
        public Boolean ItsMe { get; }
    }
}
