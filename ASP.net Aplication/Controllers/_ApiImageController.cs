using ASP.net_Aplication.Extends;
using ASP.net_Aplication.Models.Identity;
using ASP.net_Aplication.Models.Image;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.net_Aplication.Controllers {
    [ApiController]
    [Route("/Api/Image")]
    public class _ApiImageController : ControllerBase {
        private readonly IImageRep rep;
        private readonly UserManager<DBModelAccount> userManager;

        public _ApiImageController(IImageRep rep, UserManager<DBModelAccount> userManager) {
            this.rep = rep;
            this.userManager = userManager;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ShowModelImage>> Read(Int32 page = 0) {
            IEnumerable<ShowModelImage> data = this.rep.GetPage(page, "");
            return data.Any() ? this.NotFound() : this.Ok(data);
        }

        [HttpGet]
        [Route("{imageID}/{page}")]
        public ActionResult<ShowModelImage> Read(String imageID, Int32 page = 0) {
            ShowModelImage data = this.rep.GetImage(imageID, "", page);

            return data is null ? this.NotFound() : new OkObjectResult(data);
        }

        [HttpPost]
        [AuthorizationToken]
        public async Task<ActionResult<ShowModelImage>> Create([FromForm] AddModelImage model) {
            String userID = userManager.GetUserId(this.User);

            ShowModelImage data = new(await rep.Add(model, userID), "");

            return this.Created($"/api/Image/{data.ImageID}/0", data);
        }

        [HttpPut]
        [AuthorizationToken]
        public ActionResult<ShowModelImage> Update([FromForm] UpdateModelImage model) {
            ShowModelImage data = new(rep.UpdateTitle(model), "");

            return data is null ? this.NotFound() : new OkObjectResult(data);
        }

        [HttpDelete]
        [AuthorizationToken]
        public ActionResult Delete([FromForm] String imageID) {
            ShowModelImage data = new(
                rep.Delete(imageID), "");

            return data is null ? this.NotFound() : new OkObjectResult(data);
        }
    }
}
