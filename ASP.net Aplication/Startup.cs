using ASP.net_Aplication.Extends;
using ASP.net_Aplication.Models.Comment;
using ASP.net_Aplication.Models.Comment.EFCommentRep;
using ASP.net_Aplication.Models.Database;
using ASP.net_Aplication.Models.Identity;
using ASP.net_Aplication.Models.Image;
using ASP.net_Aplication.Models.Image.EFImageRep;
using ASP.net_Aplication.Models.Rate;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Reflection;
using System.Text.Json.Serialization;

namespace ASP.net_Aplication {
    public class Startup {
        public Startup(IConfiguration configuration) {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddControllersWithViews();
            //session
            services.AddSession();
            //api
            services.AddSingleton<AuthorizationApi>();
            services.AddMvc()
                .AddMvcOptions(o => o.Filters.AddService<AuthorizationApi>())
                .AddJsonOptions(o => o.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull);
            //database
            if (!UnitTestDetector.IsRunningFromTest) {
                services.AddDbContext<DbConnect>(o => o.UseSqlServer(this.Configuration["DataBase:Connect"]));
            }
            
            services.AddTransient<IRep, Rep>();
            //identity
            services.AddIdentity<DBModelAccount, IdentityRole>()
                .AddEntityFrameworkStores<DbConnect>()
                .AddDefaultTokenProviders()
                .AddErrorDescriber<PLIdentityErrors>();
            //Authorization
            services.AddAuthorization(o => {
                foreach (FieldInfo p in typeof(Role).GetFields()) {
                    String role = (String)p.GetValue(null);
                    o.AddPolicy(role, p => p.RequireRole(role));
                }
            });
            //models 
            services.AddTransient<IImageRep, EFImageRep>();
            services.AddTransient<IRateRep, EFRateRep>();
            services.AddTransient<ICommentRep, EFCommentRep>();

            IImageRep.PerPage = Int32.Parse(this.Configuration["Content:ImagePerPage"]);
            ICommentRep.PerPage = Int32.Parse(this.Configuration["Content:CommentsPerPage"]);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            } else {
                app.UseExceptionHandler("/Home/Error");
                //The default HSTS value is 30 days.You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}")
            );

            if (UnitTestDetector.IsRunningFromTest) {
                DbConnect context = app.ApplicationServices.GetService<DbConnect>();
                context.Database.EnsureCreated();
            }
        }
    }
}
