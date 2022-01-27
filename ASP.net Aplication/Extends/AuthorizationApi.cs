using ASP.net_Aplication.Models.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Net.Http.Headers;
using System;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace ASP.net_Aplication.Extends {
    public class AuthorizationApi : IAsyncAuthorizationFilter {
        private readonly UserManager<DBModelAccount> userManager;
        private readonly SignInManager<DBModelAccount> signInManager;

        public AuthorizationApi([FromServices] UserManager<DBModelAccount> userManager, [FromServices] SignInManager<DBModelAccount> signInManager) {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context) {
            if (context.Filters.OfType<AuthorizationTokenAttribute>().Any()) {
                IHeaderDictionary requestHeader = context.HttpContext.Request.Headers;

                if (!requestHeader.Keys.Contains(HeaderNames.Authorization)) {
                    context.Result = new UnauthorizedResult();
                } else {
                    String[] token = requestHeader.GetAuthentication();

                    if (await this.Validate(token[0], token[1])) {
                        GenericIdentity identity = new(token[0]);
                        GenericPrincipal principal = new(identity, null);
                        Thread.CurrentPrincipal = principal;
                    } else {
                        context.Result = new UnauthorizedResult();
                    }
                }
            }
        }

        private async Task<Boolean> Validate(String userName, String password) {
            DBModelAccount user = await userManager.FindByNameAsync(userName);

            if (user != null) {
                await this.signInManager.SignOutAsync();

                return (await signInManager.PasswordSignInAsync(user, password, false, false)).Succeeded;
            }
            return false;
        }
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class AuthorizationTokenAttribute : Attribute, IFilterMetadata { }
}
