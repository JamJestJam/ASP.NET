using ASP.net_Aplication.Models.Comment;
using ASP.net_Aplication.Models.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ASP.net_Aplication.Models.Image {
    public class SchowModelImage {
        [HiddenInput]
        public String ImageID { get; set; }

        //public Boolean Yours { get; set; }

        public Byte[] ImageSRC { get; set; }

        public String ImageTitle { get; set; }

        public Int32 CountRateUp { get; set; }

        public Int32 CountComment { get; set; }

        public DateTime CreateDate { get; set; }

        public Int32 CountRateDown { get; set; }

        public Boolean RateValueTrue { get; set; }

        public Boolean RateValueFalse { get; set; }

        public ShowModelAuthor Author { get; set; }

        [HiddenInput]
        public String ReturnUrl { get; set; }

        public IEnumerable<ShowModelComment> Comments { get; set; } = new List<ShowModelComment>();
    }
}
