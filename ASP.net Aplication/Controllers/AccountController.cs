using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASP.net_Aplication.Models.Database;
using ASP.net_Aplication.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace ASP.net_Aplication.Controllers {
    public class AccountController : Controller {
        private readonly UserManager<DBModelAccount> userManager;
        private readonly SignInManager<DBModelAccount> signInManager;

        public AccountController(UserManager<DBModelAccount> userManager, SignInManager<DBModelAccount> signInManager) {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login(String returnUrl) {
            return this.View(new ModelLogin {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(ModelLogin model) {
            if (this.ModelState.IsValid) {
                DBModelAccount user = await userManager.FindByNameAsync(model.Login);

                if (user != null) {
                    await signInManager.SignOutAsync();
                    if ((await signInManager.PasswordSignInAsync(user, model.Password, false, false)).Succeeded) {
                        return this.Redirect(model?.ReturnUrl ?? "/");
                    }
                }
            }

            this.ModelState.AddModelError("", "Nieprawidłowa nazwa użytkownika lub hasło");
            return this.View(model);
        }

        [HttpGet]
        public IActionResult Register(String returnUrl) {
            return this.View(new ModelRegister {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(ModelRegister model) {
            if (this.ModelState.IsValid) {
                DBModelAccount userData = new() {
                    PhoneNumber = model.PhoneNumber,
                    FirstName = model.FirstName,
                    BirthDate = model.BirthDate,
                    LastName = model.LastName,
                    UserName = model.UserName,
                    Email = model.Email,
                };
                IdentityResult newUser = await userManager.CreateAsync(userData, model.Password1);

                if (newUser.Succeeded) {
                    await signInManager.SignInAsync(userData, true);
                    return this.Redirect(model?.ReturnUrl ?? "/");
                }

                foreach (IdentityError error in newUser.Errors)
                    this.ModelState.AddModelError(error.Code, error.Description);

                this.ModelState.AddModelError("Error", "Nie udało się zarejestrować");
            }

            return this.View(model);
        }

        [HttpGet]
        [Authorize]
        public async Task<RedirectResult> Logout(String returnUrl = "/") {
            await signInManager.SignOutAsync();
            return this.Redirect(returnUrl);
        }
    }
}
