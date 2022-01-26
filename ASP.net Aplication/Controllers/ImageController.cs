using ASP.net_Aplication.Extends;
using ASP.net_Aplication.Models.Comment;
using ASP.net_Aplication.Models.Identity;
using ASP.net_Aplication.Models.Image;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ASP.net_Aplication.Controllers {
    public class ImageController : Controller {
        private readonly IImageRep rep;
        private readonly ICommentRep repComment;
        private readonly UserManager<DBModelAccount> userManager;

        public ImageController(IImageRep rep, ICommentRep repComment, UserManager<DBModelAccount> userManager) {
            this.userManager = userManager;
            this.repComment = repComment;
            this.rep = rep;
        }

        public IActionResult Index(String imageID, Int32 page) {
            Int32 count = repComment.Count(imageID);
            Int32 newPage = page;
            if (page < 0)
                newPage = count;
            if (page > count)
                newPage = 0;
            if (page != newPage)
                return this.RedirectToAction("Index", "Image", new { imageID, page = newPage });

            this.ViewData["count"] = count;
            this.ViewData["actual"] = page;

            ShowModelImage data =
                this.rep.GetImage(imageID, userManager.GetUserId(this.User), page);

            return data is null ? this.NotFound() : this.View(model: data);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Add(String returnUrl) {
            return this.View(new AddModelImage() { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(AddModelImage model) {
            if (this.ModelState.IsValid) {
                await rep.Add(model, userManager.GetUserId(User));

                return this.Redirect("/");
            } else {
                return this.View();
            }
        }

        [HttpGet]
        [Authorize]
        public IActionResult Update(String imageID, String returnUrl) {
            UpdateModelImage data = rep.GetImageUpdate(imageID, userManager.GetUserId(this.User));
            data.ReturnUrl = returnUrl;

            return data.Author.ItsMe ?
                this.View(model: data) :
                this.StatusCode(403);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Update(UpdateModelImage model) {
            if (this.ModelState.IsValid) {
                if (!rep.GetImageUpdate(model.ImageID, userManager.GetUserId(this.User)).Author.ItsMe)
                    return this.StatusCode(403);

                rep.UpdateTitle(model);

                return this.Redirect(model?.ReturnUrl ?? "/");
            } else {
                return this.View();
            }
        }

        [HttpGet]
        [Authorize(Role.Admin)]
        public IActionResult UpdateAdmin(String imageID, String retunUrl) {
            UpdateModelImage data = rep.GetImageUpdate(imageID, userManager.GetUserId(this.User));
            data.ReturnUrl = retunUrl;

            return this.View(model: data);
        }

        [HttpPost]
        [Authorize(Role.Admin)]
        public IActionResult UpdateAdmin(UpdateModelImage model) {
            if (this.ModelState.IsValid) {
                rep.UpdateTitle(model);

                return this.Redirect(model?.ReturnUrl ?? "/");
            } else {
                return this.View();
            }
        }

        [HttpGet]
        [Authorize]
        public IActionResult Delete(String imageID, String returnUrl) {
            ShowModelImage data = rep.GetImage(imageID, userManager.GetUserId(this.User), 0);
            data.ReturnUrl = returnUrl;

            return data.Author.ItsMe ?
                this.View(model: data) :
                this.StatusCode(403);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Delete(String ImageID) {
            if (this.ModelState.IsValid) {
                UpdateModelImage data =
                    rep.GetImageUpdate(ImageID, userManager.GetUserId(this.User));

                if (!data.Author.ItsMe)
                    return this.StatusCode(403);
                rep.Delete(ImageID);

                return this.Redirect("/");
            } else {
                return this.View();
            }
        }

        [HttpGet]
        [Authorize(Role.Admin)]
        public IActionResult DeleteAdmin(String imageID, String returnUrl) {
            ShowModelImage data = rep.GetImage(imageID, userManager.GetUserId(this.User), 0);
            data.ReturnUrl = returnUrl;

            return this.View(model: data);
        }

        [HttpPost]
        [Authorize(Role.Admin)]
        public IActionResult DeleteAdmin(String ImageID) {
            if (this.ModelState.IsValid) {
                rep.Delete(ImageID);

                return this.Redirect("/");
            } else {
                return this.View();
            }
        }
    }
}
