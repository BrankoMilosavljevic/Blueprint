using Autofac.Extensions.DependencyInjection;
using Bst.Blueprint.Data.EntityFramework;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Bst.Blueprint.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddAutofac();
                    services.AddDbContext<BlueprintContext>();
                })
                .UseStartup<Startup>();
    }
}
