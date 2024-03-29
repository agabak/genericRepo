using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kabunga.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace Kabunga
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
                       RunSeeding(host);
                       host.Run();
        }

        private static void RunSeeding(IHost host)
        {
            var scopeFactory = host.Services.GetService<IServiceScopeFactory>();
            using(var scope = scopeFactory.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetService<DataSeed>();
                seeder.Seed();
            }   
        }


        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
               .ConfigureAppConfiguration(SetAppConfiguration)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void SetAppConfiguration(HostBuilderContext ctx, IConfigurationBuilder builder)
        {
            builder.Sources.Clear();
            builder.AddJsonFile("config.json", false, true)
                   .AddEnvironmentVariables();
        }
    }
}
