using Microsoft.AspNetCore.Hosting;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;


namespace WebApplication2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return new WebHostBuilder()
                   .UseKestrel()
                   .ConfigureServices(s => s.AddAutofac())
                   .ConfigureLogging((hostingContext, loggingBuilder) =>
                   {
                       loggingBuilder.AddConsole();
                   })
                   .UseStartup<Startup>();
        }
    }
}
