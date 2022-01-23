using ASP.net_Aplication.Models;
using ASP.net_Aplication.Models.Identity;
using ASP.net_Aplication.Models.Image;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace ASP.net_Aplication.Controllers {
    public class HomeController : Controller {
        private readonly IImageRep rep;
        private readonly UserManager<DBModelAccount> userManager;

        public HomeController(IImageRep rep, UserManager<DBModelAccount> userManager) {
            this.rep = rep;
            this.userManager = userManager;
        }

        public IActionResult Index(Int32 page) {
            Int32 count = rep.CountPages();
            Int32 newPage = page;
            if (page < 0)
                newPage = count;
            if (page > count)
                newPage = 0;
            if (page != newPage)
                return this.RedirectToAction("Index", "Home", new { page = newPage });

            this.ViewData["count"] = count;
            this.ViewData["actual"] = page;

            IEnumerable<ShowModelImage> data =
                rep.GetPage(page, userManager.GetUserId(this.User));

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
