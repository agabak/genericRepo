using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kabunga.Data;
using Kabunga.Repositories;
using Kabunga.Repositories.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Kabunga
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(opt => opt.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));
            services.AddControllersWithViews();
            services.AddTransient<DataSeed>();
            services.AddScoped<UserRepository>();
            services.AddScoped<ShopRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsEnvironment("Development"))
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default",
                           "{controller}/{action}/{id?}",
                           new {controller ="Shop", action="Index"});
            });
        }
    }
}
