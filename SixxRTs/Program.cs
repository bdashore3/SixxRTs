using Microsoft.Extensions.DependencyInjection;
using SixxRTs.Handler;
using System.Threading.Tasks;

namespace SixxRTs
{
    class Program
    {
        private static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddScoped<ClientKeeper>();
            services.AddTransient<StreamEventHandler>();
            return services;
        }

        static async Task Main(string[] args)
        {
            var services = ConfigureServices();

            var serviceProvider = services.BuildServiceProvider();

            await serviceProvider.GetService<RtBot>().Launch(args[0]);
        }
    }
}
