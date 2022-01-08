using ASP.net_Aplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ASP.net_Aplication.Controllers {
    [Authorize]
    public class AccountController : Controller {
        private readonly UserManager<ModelAccount> userManager;
        private readonly SignInManager<ModelAccount> signInManager;

        public AccountController(UserManager<ModelAccount> userManager, SignInManager<ModelAccount> signInManager) {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(String returnUrl) {
            return this.View(new ModelLogin {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(ModelLogin data) {
            if (this.ModelState.IsValid) {
                ModelAccount user = await userManager.FindByNameAsync(data.Login);

                if (user != null) {
                    await signInManager.SignOutAsync();
                    if ((await signInManager.PasswordSignInAsync(user, data.Password, false, false)).Succeeded) {
                        return this.Redirect(data?.ReturnUrl ?? "/");
                    }
                }
            }

            this.ModelState.AddModelError("", "Nieprawidłowa nazwa użytkownika lub hasło");
            return this.View(data);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(String returnUrl) {
            return this.View(new ModelAccount {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(ModelAccount data) {
            if (this.ModelState.IsValid) {
                IdentityResult newUser = await userManager.CreateAsync(data, data.PasswordText);
                if (newUser.Succeeded) {
                    await signInManager.SignInAsync(data, true);
                    return this.Redirect(data?.ReturnUrl ?? "/");
                }

                foreach (IdentityError error in newUser.Errors)
                    this.ModelState.AddModelError(error.Code, error.Description);

                this.ModelState.AddModelError("Error", "Nie udało się zarejestrować");
            }

            return this.View(data);
        }

        public async Task<RedirectResult> Logout(String returnUrl = "/") {
            await signInManager.SignOutAsync();
            return this.Redirect(returnUrl);
        }
    }
}
