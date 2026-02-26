using Microsoft.Extensions.DependencyInjection;
using W06.Data;
using W06.Services;

namespace W06
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var gameEngine = serviceProvider.GetService<GameEngine>();

            gameEngine?.Run();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IContext, DataContext>();
            services.AddTransient<GameEngine>();
        }
    }
}
