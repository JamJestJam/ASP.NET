using ExpressiveAnnotations.Attributes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace ASP.net_Aplication.Models {
    enum Role {
        User,
        Admin,
    }

    public class ModelAccount : IdentityUser {

        #region New variables =================================================================

        [PersonalData]
        [Required(ErrorMessage = "Wymagane jest podanie imienia")]
        public String FirstName { get; set; }
        [PersonalData]
        [Required(ErrorMessage = "Wymagane jest podanie nazwiska")]
        public String LastName { get; set; }
        [PersonalData]
        [AssertThat("BirthDate <= Today()", ErrorMessage = "Urodziłeś się w przyszłości?")]
        [Required(ErrorMessage = "Wymagane jest podanie daty urodzenia")]
        public DateTime BirthDate { get; set; }

        #endregion

        #region Model =========================================================================

        [NotMapped]
        [HiddenInput]
        public String ReturnUrl { get; set; }
        [NotMapped]
        [Required(ErrorMessage = "Wymagane jest podanie hasła")]
        public String PasswordText { get; set; }
        [Required(ErrorMessage = "Wymagane jest podanie imienia")]

        #endregion

        #region Overide =======================================================================

        public override String UserName { get => base.UserName; set => base.UserName = value; }
        [Required(ErrorMessage = "Wymagane jest podanie Emaila")]
        public override String Email { get => base.Email; set => base.Email = value; }

        #endregion

        #region Connect =======================================================================

        public IEnumerable<ModelImage> Images;

        public IEnumerable<ModelRate> Rates;

        public IEnumerable<ModelComment> Comments;

        #endregion
    }

    public class ModelLogin {

        [Required(ErrorMessage = "Login jest wymagany")]
        public String Login { get; set; }
        [UIHint("password")]
        [Required(ErrorMessage = "Hasło jest wymagane")]
        public String Password { get; set; }

        [HiddenInput]
        public String ReturnUrl { get; set; } = "/";
    }

    public static class IdentitySeedData {
        private static readonly List<ModelAccount> users = new() {
            new ModelAccount() {
                UserName = "Marek",
                FirstName = "Marek",
                LastName = "Michura",
                PasswordHash = "zaq1@WSX",
                Email = "email@email.com",
                BirthDate = new DateTime(1998, 11, 25)
            },
            new ModelAccount() {
                UserName = "Karola",
                FirstName = "Karola",
                LastName = "Nazwisko",
                PasswordHash = "zaq1@WSX",
                Email = "Karola@email.com",
                BirthDate = new DateTime(1990, 10, 12),
            },
            new ModelAccount() {
                UserName = "Jaszczur",
                FirstName = "Jaszczur",
                LastName = "Nazwisko",
                PasswordHash = "zaq1@WSX",
                Email = "Jaszczur@email.com",
                BirthDate = new DateTime(2001, 01, 01)
            }
        };

        private static readonly List<ModelAccount> admins = new() {
            new ModelAccount() {
                UserName = "Admin",
                FirstName = "Admin",
                LastName = "Admin",
                PasswordHash = "zaq1@WSX",
                Email = "admin@email.com",
                BirthDate = new DateTime(1998, 11, 25)
            },
            new ModelAccount() {
                UserName = "Admin2",
                FirstName = "Admin",
                LastName = "Admin",
                PasswordHash = "zaq1@WSX",
                Email = "admin2@email.com",
                BirthDate = new DateTime(1990, 10, 12),
            },
        };

        private static async Task<Boolean> AddUser(ModelAccount u, Role r, UserManager<ModelAccount> userManager) {
            ModelAccount user = await userManager.FindByIdAsync(u.UserName);
            if (user == null) {
                user = new ModelAccount() {
                    UserName = u.UserName,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    BirthDate = u.BirthDate,
                };

                await userManager.CreateAsync(user, u.PasswordHash);
                await userManager.AddToRoleAsync(user, r.ToString());
                return true;
            }
            return false;
        }

        public static async void EnsurePopulated(IApplicationBuilder app) {
            using IServiceScope scope = app.ApplicationServices.CreateScope();
            UserManager<ModelAccount> userManager = (UserManager<ModelAccount>)scope
                .ServiceProvider.GetRequiredService(typeof(UserManager<ModelAccount>));
            RoleManager<IdentityRole> roleManager = (RoleManager<IdentityRole>)scope
                .ServiceProvider.GetRequiredService(typeof(RoleManager<IdentityRole>));

            foreach (Role r in (Role[])Enum.GetValues(typeof(Role))) {
                if (!await roleManager.RoleExistsAsync(r.ToString())) {
                    await roleManager.CreateAsync(new IdentityRole(r.ToString()));
                }
            }

            foreach (ModelAccount u in users)
                await AddUser(u, Role.User, userManager);

            foreach (ModelAccount u in admins)
                await AddUser(u, Role.Admin, userManager);
        }
    }
}
