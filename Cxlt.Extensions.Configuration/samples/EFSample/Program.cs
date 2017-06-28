using System;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EFSample
{
    class Program
    {
        public static IConfigurationRoot Configuration { get; set; }

        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .AddEntityFramework(options =>
                {
                    // 这里使用SQLite作为演示
                    options.UseSqlite("Filename=config.db");
                });



            var services = new ServiceCollection();
            



            var serviceProvider = services.BuildServiceProvider();




            Configuration = builder.Build();
        }
    }
}