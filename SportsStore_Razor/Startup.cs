using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SportsStore_Razor.Data;
using SportsStore_Razor.Repositories;

namespace SportsStore_Razor
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddTransient<SeedData>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddDbContext<DataContext>(x => x.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc(option => option.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, SeedData seeder)
        {
            seeder.EnsurePopulated();
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseMvc(routes => {
                routes.MapRoute(
                    name: null,
                    template: "{category}/Strona{productPage:int}",
                    defaults: new { Controller = "Product", action = "List" }
                    );
                routes.MapRoute(
                    name: null,
                    template: "Strona{productPage:int}",
                    defaults: new { Controller = "Product", action = "List", productPage = 1}
                    );
                routes.MapRoute(
                    name: null,
                    template: "{category}",
                    defaults: new { Controller = "Product", action = "List", productPage = 1 }
                    );
                routes.MapRoute(
                    name: null,
                    template: "",
                    defaults: new { Controller = "Product", action = "List", productPage = 1 }
                    );
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Product}/{action=List}/{id?}");
            });
        }
    }
}
