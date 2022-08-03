using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace CourierService
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            IConfiguration configuration = builder.Build();

            IServiceCollection services = new ServiceCollection();
            services.AddSingleton(configuration);
            services.AddTransient<DataEntry>();
            var serviceProvider = services.BuildServiceProvider();
            serviceProvider.GetService<DataEntry>().Run();

        }
    }
}
