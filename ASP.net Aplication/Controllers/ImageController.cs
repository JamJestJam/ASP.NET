using ASP.net_Aplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ASP.net_Aplication.Controllers {
    public class ImageController : Controller {
        private readonly IImageRep image;
        private readonly UserManager<ModelAccount> userManager;

        public ImageController(IImageRep image, UserManager<ModelAccount> userManager) {
            this.userManager = userManager;
            this.image = image;
        }

        public async Task<IActionResult> Index(Int32 id) {
            ModelAccount tmp = await this.userManager.FindByNameAsync(this.User.Identity.Name);
            this.ViewData["UserID"] = tmp.Id;

            return this.View(model: image.GetImage(id));
        }

        [HttpGet]
        [Authorize]
        public IActionResult Add() {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(ModelImage image) {
            String id = (await this.userManager.FindByNameAsync(this.User.Identity.Name)).Id;
            image.AuthorID = id;

            if (this.ModelState.IsValid) {
                using MemoryStream ms = new();
                await image.ImageName.CopyToAsync(ms);
                image.ImageSRC = ms.ToArray();

                this.image.Add(image);
                return this.Redirect("/");
            } else {
                ModelAccount tmp = await this.userManager.FindByNameAsync(this.User.Identity.Name);
                this.ViewData["UserID"] = tmp.Id;
                return this.View();
            }
        }

        public IActionResult Update() {
            return this.View();
        }
    }
}
