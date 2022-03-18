using Autofac;
using DTA.Application.Autofact;
using Dukkantek.EntityFrameWork.Context;
using Dukkantek.Infra.IoC;
using Dukkantek.Repo.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DukkantekInventory
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new AutofacModule());
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EFContext>(options =>
                               options.UseSqlServer(Configuration.GetConnectionString("Default")));//, ServiceLifetime.Transient


            services.AddAntiforgery();

            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "Dukkantek.BACKEND.API";

                };

            });

            services.AddControllers();

            RegisterServices(services);

        }

        private static void RegisterServices(IServiceCollection services)
        {
            DependencyContainer.RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            var configuration = Configuration.GetSection("Logging"); //log levels set in your configuration
            loggerFactory.AddFile(configuration);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseOpenApi();
            app.UseSwaggerUi3();
            app.UseHttpsRedirection();
            app.UseRouting();

            app.Use(async (context, next) =>
            {
                context.Response.Headers.Remove("Server");
                context.Response.Headers.Remove("X-powered-by");
                context.Response.Headers.Remove("X-AspNet-Version");
                context.Response.Headers.Remove("X-AspNetMvc-Version");
                await next();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
