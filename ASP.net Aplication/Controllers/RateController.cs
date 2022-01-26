using ASP.net_Aplication.Models.Identity;
using ASP.net_Aplication.Models.Rate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ASP.net_Aplication.Controllers {
    public class RateController : Controller {
        private readonly IRateRep rep;
        private readonly UserManager<DBModelAccount> userManager;

        public RateController(IRateRep rep, UserManager<DBModelAccount> userManager) {
            this.rep = rep;
            this.userManager = userManager;
        }

        public IActionResult Like(String imageID, String returnUrl = "/") {
            this.rep.Like(imageID, userManager.GetUserId(this.User), true);

            return this.Redirect(returnUrl);
        }

        public IActionResult DisLike(String imageID, String returnUrl = "/") {
            this.rep.Like(imageID, userManager.GetUserId(this.User), false);

            return this.Redirect(returnUrl);
        }
    }
}
