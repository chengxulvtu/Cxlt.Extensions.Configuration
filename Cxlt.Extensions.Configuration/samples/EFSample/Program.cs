using System;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

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


            



            Configuration = builder.Build();
        }
    }
}