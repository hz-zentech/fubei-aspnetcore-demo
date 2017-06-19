using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace FubeiDemoMvcApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var hostingConfig = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("hosting.json", true).Build();
            
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseConfiguration(hostingConfig)
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}