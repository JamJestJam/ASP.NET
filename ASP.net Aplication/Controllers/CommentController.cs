using ASP.net_Aplication.Models.Comment;
using ASP.net_Aplication.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ASP.net_Aplication.Controllers {
    public class CommentController : Controller {
        private readonly UserManager<DBModelAccount> userManager;
        private readonly ICommentRep rep;

        public CommentController(UserManager<DBModelAccount> userManager, ICommentRep rep) {
            this.userManager = userManager;
            this.rep = rep;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Add(String commentID) {
            return this.View(model: new AddModelComment() {
                ImageID = commentID
            });
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(AddModelComment model) {
            if (this.ModelState.IsValid) {
                rep.Add(new DBModelComment() {
                    ImageID = model.ImageID,
                    CommentText = model.CommentText,
                    AuthorID = userManager.GetUserId(this.User),
                });

                return this.RedirectToAction("Index", "Image", new { imageID = model.ImageID });
            } else {
                return this.View();
            }
        }

        [HttpGet]
        [Authorize]
        public IActionResult Update(String commentID, String returnUrl) {
            UpdateModelComment data = rep.GetCommentUpdate(commentID, userManager.GetUserId(this.User));
            data.ReturnUrl = returnUrl;

            return data.Author.ItsMe ?
                this.View(model: data) :
                this.StatusCode(403);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Update(UpdateModelComment model) {
            if (this.ModelState.IsValid) {
                if (!rep.GetCommentUpdate(model.CommentID, userManager.GetUserId(this.User)).Author.ItsMe)
                    return this.StatusCode(403);

                rep.UpdateText(model);
                return this.Redirect(model?.ReturnUrl ?? "/");
            } else {
                return this.View();
            }
        }

        [HttpGet]
        [Authorize(Role.Admin)]
        public IActionResult UpdateAdmin(String commentID, String returnUrl) {
            UpdateModelComment data = rep.GetCommentUpdate(commentID, userManager.GetUserId(this.User));
            data.ReturnUrl = returnUrl;

            return this.View(model: data);
        }

        [HttpPost]
        [Authorize(Role.Admin)]
        public IActionResult UpdateAdmin(UpdateModelComment model) {
            if (this.ModelState.IsValid) {
                rep.UpdateText(model);
                return this.Redirect(model?.ReturnUrl ?? "/");
            } else {
                return this.View();
            }
        }

        [HttpGet]
        [Authorize]
        public IActionResult Delete(String commentID, String returnUrl) {
            ShowModelComment data = rep.Get(commentID, userManager.GetUserId(this.User));
            data.ReturnUrl = returnUrl;

            return data.Author.ItsMe ?
                this.View(model: data) :
                this.StatusCode(403);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Delete(String CommentID) {
            if (this.ModelState.IsValid) {
                ShowModelComment data =
                    rep.Get(CommentID, userManager.GetUserId(this.User));

                if (!data.Author.ItsMe)
                    return this.StatusCode(403);

                rep.Delete(CommentID);

                return this.RedirectToAction("Index", "Image", new { imageID = data.ImageID });
            } else {
                return this.View();
            }
        }

        [HttpGet]
        [Authorize(Role.Admin)]
        public IActionResult DeleteAdmin(String commentID, String returnUrl) {
            ShowModelComment data = rep.Get(commentID, userManager.GetUserId(this.User));
            data.ReturnUrl = returnUrl;

            return this.View(model: data);
        }

        [HttpPost]
        [Authorize(Role.Admin)]
        public IActionResult DeleteAdmin(String CommentID) {
            if (this.ModelState.IsValid) {
                ShowModelComment data = rep.Get(CommentID, "");

                rep.Delete(CommentID);

                return this.RedirectToAction("Index", "Image", new { imageID = data.ImageID });
            } else {
                return this.View();
            }
        }
    }
}
