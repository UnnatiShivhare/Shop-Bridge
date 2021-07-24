using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using ThinkBridge.ShopBridge.ProductService.Api;

namespace ThinkBridge.ShopBridge.ProductService
{
    /// <summary>
    /// Program class having is the starting entry execution point of .Net core application
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        /// <summary>
        /// Creates the web host builder.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
