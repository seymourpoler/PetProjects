using System.Net.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WiMi.CrossCutting.Serializers;
using WiMi.Domain.Pages;
using WiMi.Domain.Pages.Create;
using WiMi.Domain.Pages.Find;
using WiMi.Domain.Pages.Remove;
using WiMi.Repositories.SQLite;

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
            services.AddTransient<IRemovePageRepository, RemovePageRepository>();
            services.AddTransient<IExistPageRepository, ExistPageRepository>();
            services.AddTransient<IFindPageRepository, FindPageRepository>();
			services.AddTransient<ISavePageRepository, SavePageRepository>();
            services.AddTransient<IPageRemover, PageRemover>();
            services.AddTransient<IPageFinder, PageFinder>();
            services.AddTransient<IPageCreator, PageCreator>();
            services.AddTransient<ISerializer, JsonSerializer>();

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
                    name: "page delete",
                    template: "api/pages/{id}",
                    defaults: new { controller = "DeletePage", action = "Delete", httpMethod = new HttpMethod("DELETE") });

                routes.MapRoute(
                    name: "page update",
                    template: "pages/edit/{id}",
                    defaults: new { controller = "UpdatePage", action = "Edit" });

                routes.MapRoute(
                    name: "pageUpdater",
                    template: "api/pages",
                    defaults: new { controller = "UpdatePage", action = "Update", httpMethod = new HttpMethod("PUT") });

                routes.MapRoute(
                    name: "page index",
                    template: "pages/index",
                    defaults: new { controller = "FindPages", action = "Index" });

                routes.MapRoute(
					name: "pagefinder",
					template: "api/pages",
					defaults: new { controller = "FindPages", action = "Find", httpMethod = new HttpMethod("GET") });

                routes.MapRoute(
                    name: "page new",
                    template: "pages/new",
                    defaults: new { controller = "CreatePage", action = "New" });

                routes.MapRoute(
                    name: "pagecreator",
                    template: "api/pages",
					defaults: new { controller = "CreatePage", action = "Create", httpMethod = new HttpMethod("POST") });

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
