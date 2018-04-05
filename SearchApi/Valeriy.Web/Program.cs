using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Serilog;
using Valeriy.Domain.Extensions;

namespace Valeriy.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel()
                .UseStartup<Startup>().ConfigureLogging((hostingContext, logging) =>
                {
                    logging.AddConsoleLogger();
                    logging.AddFileLogger();
                })
                .Build();
    }
}
