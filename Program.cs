using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace WebApiTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Build and run the host
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // Specify the Startup class to configure the application
                    webBuilder.UseStartup<Startup>();
                });
    }
}
