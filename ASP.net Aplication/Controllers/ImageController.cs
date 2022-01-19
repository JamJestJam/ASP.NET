using ASP.net_Aplication.Models.Identity;
using ASP.net_Aplication.Models.Image;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.net_Aplication.Controllers {
    public class ImageController : Controller {
        private readonly IImageRep rep;
        private readonly UserManager<DBModelAccount> userManager;

        public ImageController(IImageRep rep, UserManager<DBModelAccount> userManager) {
            this.userManager = userManager;
            this.rep = rep;
        }

        public IActionResult Index(Int32 id) {
            return this.View(model: this.rep.GetImage(id, userManager.GetUserId(this.User)));
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
                using MemoryStream ms = new();
                await model.ImageName.CopyToAsync(ms);

                rep.Add(new DBModelImage() {
                    ImageTitle = model.ImageTitle,
                    ImageSRC = ms.ToArray(),
                    AuthorID = userManager.GetUserId(this.User)
                });

                return this.Redirect(model?.ReturnUrl ?? "/");
            } else {
                return this.View();
            }
        }

        [HttpGet]
        [Authorize]
        public IActionResult Update(Int32 id, String returnUrl) {
            UpdateModelImage data = rep.GetImageUpdate(id, userManager.GetUserId(this.User));
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
        [Authorize]
        public IActionResult Delete(Int32 id, String returnUrl) {
            SchowModelImage data = rep.GetImage(id, userManager.GetUserId(this.User));
            data.ReturnUrl = returnUrl;

            return data.Author.ItsMe ?
                this.View(model: data) :
                this.StatusCode(403);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Delete(Int32 ImageID) {
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
    }
}
