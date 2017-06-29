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
                    options.TableName = "configs";
                    // 这里使用SQLite作为演示
                    options.DbContextOptions.UseSqlite("Filename=config.db");
                });


            Configuration = builder.Build();

            var services = new ServiceCollection();

            var serviceProvider = services.BuildServiceProvider();


            Console.WriteLine(Configuration["AppId"]);
            Console.WriteLine(Configuration["Logging:IncludeScopes"]);
            Console.WriteLine(Configuration["Logging:LogLevel:Default"]);
            Console.WriteLine(Configuration["Logging:LogLevel:System"]);
            Console.WriteLine(Configuration["Logging:LogLevel:Microsoft"]);
            Console.WriteLine(Configuration["GrantTypes:0:Name"]);
            Console.WriteLine(Configuration["GrantTypes:1:Name"]);
            Console.WriteLine(Configuration["GrantTypes:2:Name"]);
        }
    }
}