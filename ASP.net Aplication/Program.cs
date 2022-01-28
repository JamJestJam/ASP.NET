using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;

namespace ASP.net_Aplication {
    public class Program {
        public static void Main(String[] args) {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(String[] args) {
            return Host.CreateDefaultBuilder(args)
                .UseDefaultServiceProvider(o => o.ValidateScopes = false)
                .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
        }
    }
}
