using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FubeiDemoMvcApplication.Config;
using FubeiDemoMvcApplication.Services;
using FubeiDemoMvcApplication.Services.Impl;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;

namespace FubeiDemoMvcApplication
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
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
            
            // Adds services required for using options.
            services.AddOptions();
            services.AddSingleton<IFubeiSignatureService, FubeiSignatureServiceImpl>();
            services.AddTransient<IFubeiApiRequestService, FubeiApiRequestServiceImpl>();
            services.AddSingleton<IOrderService, OrderServiceImpl>();
            // swagger-ui
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Fubei Api Tester", Description = "Powered by Asp.Net Core MVC 1.1", Version = "v1" });
            });
            // Register the IConfiguration instance which MyOptions binds against.
            services.Configure<ApplicationConfiguration>(Configuration.GetSection("ApplicationConfiguration"));
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
                    name: "Default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new
                    {
                        controller = "Home", action = "Index"
                    }
                );
            });
            
            // swagger-ui
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Fubei API V1");
            });
            
//            app.Use(new Func<RequestDelegate, RequestDelegate>(nextApp => new RequestServicesContainerMiddleware(nextApp, app.ApplicationServices).Invoke));
        }
    }
}