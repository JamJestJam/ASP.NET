using ASP.net_Aplication.Models;
using ASP.net_Aplication.Models.Identity;
using ASP.net_Aplication.Models.Image;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.net_Aplication.Controllers {
    public class HomeController : Controller {
        private readonly IImageRep image;
        private readonly UserManager<DBModelAccount> userManager;

        public HomeController(IImageRep image, UserManager<DBModelAccount> userManager) {
            this.image = image;
            this.userManager = userManager;
        }
        
        public IActionResult Index() {
            IEnumerable<SchowModelImage> data = 
                image.GetPage(0, userManager.GetUserId(this.User));

            return this.View(model: data);
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
