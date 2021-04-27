using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace MichaelPavichFinal
{
    /// <summary>
    /// Defines the program class.
    /// </summary>
    /// <author>
    /// Michael Pavich
    /// </author>
    /// <date>
    /// Started 4/27/2021
    /// </date>
    public class Program
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
        /// Creates the host builder.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                              .UseDefaultServiceProvider(
                                  options => options.ValidateScopes = false);
                });
    }
}