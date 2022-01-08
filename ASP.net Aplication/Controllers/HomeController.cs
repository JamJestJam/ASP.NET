using ASP.net_Aplication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ASP.net_Aplication.Controllers {
    public class HomeController : Controller {
        private readonly IImageRep image;
        private readonly UserManager<ModelAccount> userManager;

        public HomeController(IImageRep image, UserManager<ModelAccount> userManager) {
            this.image = image;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index() {
            String tmp = "";
            try {
                tmp = (await userManager.FindByNameAsync(this.User.Identity.Name)).Id;
            } catch { }
            return this.View(model: this.image.GetPage(0, tmp));
        }

        public IActionResult Privacy() {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
