using Microsoft.Extensions.Hosting;
using Rox.AspNetCore;
using Rox.Blog.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Rox.Blog.Server.BlazorServer.Data;

namespace Rox.Blog.Server.BlazorServer
{
    [Dependency(
        typeof(BlogApplicationModule),
        typeof(BlogEntityFrameworkCoreModule)
        )]
    public class BlogServerBlazorModule: ModuleBase
    {
        public override Task ConfigureServices(ServicesConfigureContext context, CancellationToken cancellationToken)
        {
            var services = context.Services;

            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();
            return base.ConfigureServices(context, cancellationToken);
        }

        public override Task OnApplicationInitialization(ApplicationInitializationContext context, CancellationToken cancellationToken)
        {
            var env = context.ServiceProvider.GetService<IHostEnvironment>();
            var app = context.GetApplicationBuilder();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
            return base.OnApplicationInitialization(context, cancellationToken);
        }
    }
}
