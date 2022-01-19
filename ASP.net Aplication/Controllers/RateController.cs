using ASP.net_Aplication.Models.Identity;
using ASP.net_Aplication.Models.Rate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.net_Aplication.Controllers {
    public class RateController : Controller {
        private readonly IRateRep rep;
        private readonly UserManager<DBModelAccount> userManager;

        public RateController(IRateRep rep, UserManager<DBModelAccount> userManager) {
            this.rep = rep;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Like(Int32 id, String returnUrl = "/") {
            await this.rep.Like(id, userManager.GetUserId(this.User), true);

            return this.Redirect(returnUrl);
        }

        public async Task<IActionResult> DisLike(Int32 id, String returnUrl = "/") {
            await this.rep.Like(id, userManager.GetUserId(this.User), false);

            return this.Redirect(returnUrl);
        }
    }
}
