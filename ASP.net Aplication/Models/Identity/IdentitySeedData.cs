using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.net_Aplication.Models.Identity {
    public static class IdentitySeedData {
        private static readonly List<DBModelAccount> users = new() {
            new DBModelAccount() {
                UserName = "Marek",
                FirstName = "Marek",
                LastName = "Michura",
                PasswordHash = "zaq1@WSX",
                Email = "email@email.com",
                BirthDate = new DateTime(1998, 11, 25)
            },
            new DBModelAccount() {
                UserName = "Karola",
                FirstName = "Karola",
                LastName = "Nazwisko",
                PasswordHash = "zaq1@WSX",
                Email = "Karola@email.com",
                BirthDate = new DateTime(1990, 10, 12),
            },
            new DBModelAccount() {
                UserName = "Jaszczur",
                FirstName = "Jaszczur",
                LastName = "Nazwisko",
                PasswordHash = "zaq1@WSX",
                Email = "Jaszczur@email.com",
                BirthDate = new DateTime(2001, 01, 01)
            }
        };

        private static readonly List<DBModelAccount> admins = new() {
            new DBModelAccount() {
                UserName = "Admin",
                FirstName = "Admin",
                LastName = "Admin",
                PasswordHash = "zaq1@WSX",
                Email = "admin@email.com",
                BirthDate = new DateTime(1998, 11, 25)
            },
            new DBModelAccount() {
                UserName = "Admin2",
                FirstName = "Admin",
                LastName = "Admin",
                PasswordHash = "zaq1@WSX",
                Email = "admin2@email.com",
                BirthDate = new DateTime(1990, 10, 12),
            },
        };

        private static async Task<Boolean> AddUser(DBModelAccount u, Role r, UserManager<DBModelAccount> userManager) {
            DBModelAccount user = await userManager.FindByIdAsync(u.UserName);
            if (user == null) {
                user = new DBModelAccount() {
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
            UserManager<DBModelAccount> userManager = (UserManager<DBModelAccount>)scope
                .ServiceProvider.GetRequiredService(typeof(UserManager<DBModelAccount>));
            RoleManager<IdentityRole> roleManager = (RoleManager<IdentityRole>)scope
                .ServiceProvider.GetRequiredService(typeof(RoleManager<IdentityRole>));

            foreach (Role r in (Role[])Enum.GetValues(typeof(Role))) {
                if (!await roleManager.RoleExistsAsync(r.ToString())) {
                    await roleManager.CreateAsync(new IdentityRole(r.ToString()));
                }
            }

            foreach (DBModelAccount u in users)
                await AddUser(u, Role.User, userManager);

            foreach (DBModelAccount u in admins)
                await AddUser(u, Role.Admin, userManager);
        }
    }
}
