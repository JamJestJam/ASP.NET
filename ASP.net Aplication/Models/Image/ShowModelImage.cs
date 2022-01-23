using ASP.net_Aplication.Models.Comment;
using ASP.net_Aplication.Models.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace ASP.net_Aplication.Models.Image {
    public class ShowModelImage {
        public ShowModelImage(DBModelImage model, String userID) {
            this.ImageID = model.ImageID;
            this.ImageSRC = model.ImageSRC;
            this.CreateDate = model.CreateDate;
            this.ImageTitle = model.ImageTitle;
            this.CountComment = model.Comments.Count();
            this.CountRateUp = model.Rates.Count(b => b.RateValue);
            this.CountRateDown = model.Rates.Count(b => !b.RateValue);
            this.RateValueTrue = model.Rates.Any(c => c.UserID == userID && c.RateValue);
            this.RateValueFalse = model.Rates.Any(c => c.UserID == userID && !c.RateValue);

            if (model.Author != null)
                this.Author = new ShowModelAuthor(model.Author, userID);
        }

        public ShowModelImage(DBModelImage model, String userID, Int32 page) : this(model, userID) {
            if (model.Comments != null)
                this.Comments = model.Comments
                    .OrderBy(a => a.CreateDate)
                    .Skip(page * ICommentRep.PerPage)
                    .Take(ICommentRep.PerPage)
                    .Select(b => new ShowModelComment(b, userID));
        }

        [HiddenInput]
        public String ImageID { get; }
        public String ImageTitle { get; }
        public Int32 CountRateUp { get; }
        public Int32 CountRateDown { get; }
        public Int32 CountComment { get; }
        public DateTime CreateDate { get; }
        public ShowModelAuthor Author { get; }
        public IEnumerable<ShowModelComment> Comments { get; }
        public Byte[] ImageSRC { get; }

        [JsonIgnore]
        public Boolean RateValueTrue { get; }
        [JsonIgnore]
        public Boolean RateValueFalse { get; }
        [JsonIgnore]
        [HiddenInput]
        public String ReturnUrl { get; set; }
    }
}
