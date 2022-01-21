using ASP.net_Aplication.Models.Comment;
using ASP.net_Aplication.Models.Image;
using ASP.net_Aplication.Models.Rate;
using ExpressiveAnnotations.Attributes;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASP.net_Aplication.Models.Identity {
    public class DBModelAccount : IdentityUser {
        [Required]
        [PersonalData]
        public String FirstName { get; set; }

        [Required]
        [PersonalData]
        public String LastName { get; set; }

        [Required]
        [PersonalData]
        [DataType(DataType.Date)]
        [AssertThat("BirthDate <= Today()")]
        public DateTime BirthDate { get; set; }


        public IEnumerable<DBModelImage> Images;

        public IEnumerable<DBModelRate> Rates;

        public IEnumerable<DBModelComment> Comments;
    }
}
