

using ASP.net_Aplication.Models.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Linq;

namespace ASP.net_Aplication_Test {
    public class SeleniumServerFactory<TStartup> : IDisposable where TStartup : class {
        public readonly IHost _host;

        public Uri BaseAddress { get; }

        public SeleniumServerFactory(String DB=" ") {
            IHostBuilder builder = Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(webBuilder => {
                    webBuilder.UseStartup<TStartup>();

                    String relativePathToProject = Path.Join("ASP.net Aplication");
                    webBuilder.UseSolutionRelativeContentRoot(relativePathToProject);

                    webBuilder.ConfigureServices(service => service.AddDbContext<DbConnect>(opt => opt.UseInMemoryDatabase(DB)));

                    webBuilder.UseUrls("http://127.0.0.1:0");
                });

            _host = builder.Build();
            _host.Start();

            this.BaseAddress = new Uri(_host.Services.GetRequiredService<IServer>().Features.Get<IServerAddressesFeature>().Addresses.First());
        }

        public void Dispose() {
            this._host.Dispose();
            GC.SuppressFinalize(this);
        }
    }

    //public class SeleniumServerFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class {
    //    public IHost HostWeb { get; set; }

    //    public SeleniumServerFactory() { }

    //    protected override TestServer CreateServer(IWebHostBuilder builder) {
    //        return base.CreateServer(builder);
    //    }

    //    protected override IHost CreateHost(IHostBuilder builder) {
    //        HostWeb = builder.Build();

    //        HostWeb.Start();

    //        return HostWeb;
    //    }

    //    protected override void ConfigureWebHost(IWebHostBuilder builder) {
    //        builder.ConfigureKestrel(options => {
    //            options.Listen(System.Net.IPAddress.Loopback, 0, listenOptions => {
    //                listenOptions.UseHttps();
    //            });
    //        })
    //            .UseUrls("https://localhost")
    //            .UseEnvironment("Test");
    //    }
    //}
}
