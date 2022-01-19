using ASP.net_Aplication.Models.Comment;
using ASP.net_Aplication.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.net_Aplication.Controllers {
    public class CommentController : Controller {
        private readonly UserManager<DBModelAccount> userManager;
        private readonly ICommentRep comment;

        public CommentController(UserManager<DBModelAccount> userManager, ICommentRep comment) {
            this.userManager = userManager;
            this.comment = comment;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Add(Int32 id) {
            return this.View(model: new AddModelComment() {
                ImageID = id
            });
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(AddModelComment model) {
            if (this.ModelState.IsValid) {
                comment.Add(new DBModelComment() {
                    ImageID = model.ImageID,
                    CommentText = model.CommentText,
                    AuthorID = userManager.GetUserId(this.User),
                });

                return this.RedirectToAction("Index", "Image", new { id = model.ImageID });
            } else {
                return this.View();
            }
        }
    }
}
