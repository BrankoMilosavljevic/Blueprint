using Autofac;
using Bst.Blueprint.Data.EntityFramework;
using Bst.Blueprint.Data.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bst.Blueprint.Api
{
    public class Startup
    {
        public static IConfiguration Configuration { get; private set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<BlueprintContext>();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new EntityFrameworkModule { DbContextOptions = CreateDbContextOptions() });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseHttpsRedirection();
            app.UseMvc();
        }

        private DbContextOptions CreateDbContextOptions()
        {
            var optionsBuilder = new DbContextOptionsBuilder();

            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("BlueprintContext"),
                b => b.MigrationsAssembly("Bst.Blueprint.Data.Migrations"));

            return optionsBuilder.Options;
        }
    }
}
