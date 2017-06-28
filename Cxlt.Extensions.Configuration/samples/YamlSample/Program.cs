using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;

namespace YamlSample
{
    class Program
    {
        public static IConfigurationRoot Configuration { get; set; }


        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddYamlFile("appsettings.yaml")
                .AddYamlFile("array.yaml");


            Configuration = builder.Build();


            var services = new ServiceCollection();
            services.AddOptions();

            services.Configure<MyOptions>(Configuration);
            services.Configure<LoggingOptions>(Configuration.GetSection("Logging"));
            services.Configure<LogLevelOptions>(Configuration.GetSection("Logging:LogLevel"));


            Console.WriteLine(Configuration["AppId"]);//输出 12345
            Console.WriteLine(Configuration["Logging:IncludeScopes"]); //输出 false
            Console.WriteLine(Configuration["Logging:LogLevel:Default"]); //输出 Debug
            Console.WriteLine(Configuration["Logging:LogLevel:System"]); //输出 Information
            Console.WriteLine(Configuration["Logging:LogLevel:Microsoft"]); //输出 Information
            Console.WriteLine(Configuration["GrantTypes:0"]); //输出 authorization
            Console.WriteLine(Configuration["GrantTypes:1"]); //输出 password
            Console.WriteLine(Configuration["GrantTypes:2"]); //输出 client_credentials

            Console.WriteLine(Configuration["0"]);//输出 A
            Console.WriteLine(Configuration["1"]);//输出 B
            Console.WriteLine(Configuration["2"]);//输出 C
            Console.WriteLine(Configuration["3"]);//输出 D


            var serviceProvider = services.BuildServiceProvider();

            var myOptionsAccessor = serviceProvider.GetService<IOptions<MyOptions>>();
            var myOptioins = myOptionsAccessor.Value;

            var loggingOptionsAccessor = serviceProvider.GetService<IOptions<LoggingOptions>>();
            var loggingOptions = loggingOptionsAccessor.Value;

            var logLevelOptionsAccessor = serviceProvider.GetService<IOptions<LogLevelOptions>>();
            var logLevelOptions = logLevelOptionsAccessor.Value;

        }
    }


    public class MyOptions
    {
        public int AppId { get; set; }

        public LoggingOptions Logging { get; set; }

        public List<string> GrantTypes { get; set; }

    }

    public class LoggingOptions
    {
        public bool IncludeScopes { get; set; }

        public LogLevelOptions LogLevel { get; set; }
    }

    public class LogLevelOptions
    {
        public string Default { get; set; }

        public string System { get; set; }

        public string Microsoft { get; set; }
    }


}