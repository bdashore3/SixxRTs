using Microsoft.Extensions.DependencyInjection;
using SixxRTs.Handler;
using SixxRTs.Helpers;
using System.Threading.Tasks;

namespace SixxRTs
{
    class Program
    {
        // Collection of services
        private static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddScoped<RtBot>();
            services.AddTransient<StreamEventHandler>();
            services.AddTransient<TweetHelper>();
            return services;
        }

        // Async Main() method to start the bot
        static async Task Main(string[] args)
        {   
            var services = ConfigureServices();

            var serviceProvider = services.BuildServiceProvider();

            await serviceProvider.GetService<RtBot>().Launch(args[0], args[1]);
        }
    }
}
