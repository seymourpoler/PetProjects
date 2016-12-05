using Data;
using Domain.Commands;
using Domain.Commands.Repositories;
using Domain.Queries;
using Infrestructura;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
            services.AddTransient<IJsonSerializer, JsonSerializer>();
            services.AddTransient<ITodoFindRepository, TodoFindRepository>();
            services.AddTransient<ITodoCreator, TodoCreator>();
            services.AddTransient<ITodoInsertRepository, TodoInsertRepository>();
            services.AddDbContext<SampleDbContext>(options => options.UseInMemoryDatabase());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                   name: "TodoIndex",
                   template: "todo/Index",
                   defaults: new { controller = "Todo", action = "Index" });

                routes.MapRoute(
                   name: "NewTodo",
                   template: "todo/New",
                   defaults: new { controller = "Todo", action = "New" });

                routes.MapRoute(
                   name: "CreateTodo",
                   template: "api/todos",
                   defaults: new { controller = "CreateTodo", action = "Create" });

                routes.MapRoute(
                    name: "HelloWorldIndex",
                    template: "HelloWorld/Index");

                routes.MapRoute(
                    name: "HelloWorldHello",
                    template: "HelloWorld/Hello");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
