using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WiMi.CrossCutting.Serializers;
using WiMi.Domain.Pages;
using WiMi.Domain.Pages.Create;
using WiMi.Repositories.SQLite;
using WiMi.Web.Controllers;

namespace WiMi.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<DataBaseConfiguration>();
			services.AddTransient<IPageRepository, PageRepository>();
            services.AddTransient<IPageCreator, PageCreator>();
            services.AddTransient<ISerializer, JsonSerializer>();
            services.AddTransient<HttpActionResultBuilder>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "page index",
                    template: "pages",
                    defaults: new { controller = "Pages", action = "Index" });

                routes.MapRoute(
                    name: "page new",
                    template: "pages/new",
                    defaults: new { controller = "Pages", action = "New" });

                routes.MapRoute(
                    name: "pagecreator",
                    template: "api/pages",
                    defaults: new { controller = "Pages", action = "Create" });

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
