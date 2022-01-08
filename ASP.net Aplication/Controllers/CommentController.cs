using ASP.net_Aplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ASP.net_Aplication.Controllers {
    [Authorize]
    public class CommentController : Controller {
        readonly UserManager<ModelAccount> userManager;
        readonly ICommentRep comment;

        public CommentController(UserManager<ModelAccount> userManager, ICommentRep comment) {
            this.userManager = userManager;
            this.comment = comment;
        }

        [HttpGet]
        public IActionResult Add(Int32 id) {
            this.ViewData["ImageID"] = id;
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ModelComment model) {
            String id = (await this.userManager.FindByNameAsync(this.User.Identity.Name)).Id;
            model.UserID = id;

            if (this.ModelState.IsValid) {
                comment.Add(model);
                return this.RedirectToAction("Index", "Image", new { id = model.ImageID });
            } else {
                return this.View();
            }
        }
    }
}
