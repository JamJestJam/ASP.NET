using ASP.net_Aplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ASP.net_Aplication.Controllers {
    [Authorize]
    public class RateController : Controller {

        private readonly IRateRep rep;
        private readonly UserManager<ModelAccount> userManager;

        public RateController(IRateRep rep, UserManager<ModelAccount> userManager) {
            this.rep = rep;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Like(Int32 id, String page = "/") {
            ModelAccount tmp = await this.userManager.FindByNameAsync(this.User.Identity.Name);
            await this.rep.Like(id, tmp.Id, true);

            return this.Redirect(page);
        }

        public async Task<IActionResult> DisLike(Int32 id, String page = "/") {
            ModelAccount tmp = await this.userManager.FindByNameAsync(this.User.Identity.Name);
            await this.rep.Like(id, tmp.Id, false);

            return this.Redirect(page);
        }
    }
}
