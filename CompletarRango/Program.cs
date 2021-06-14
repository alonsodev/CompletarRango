using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;

namespace CompletarRango
{
    class Program
    {
        public static IConfigurationRoot configuration;
        static int Main(string[] args)
        {
            // Initialize serilog logger

            try
            {
                // Start!
                MainAsync(args).Wait();
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return 1;
            }
        }

        static async Task MainAsync(string[] args)
        {
            // Create service collection

            ServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            // Create service provider

            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            // Print connection string to demonstrate configuration object is populated
            Console.WriteLine(configuration.GetConnectionString("EngieDBConnection"));

            try
            {
                if (args.Length == 0) {
                    throw new ArgumentException("Almenos debe existir el argumento 0 y debe tener un valor. Ejm.: 1,5,8", "args[0]");
                }
                serviceProvider.GetService<Execute>().Run(args[0]);

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

            }
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            // Add logging
            serviceCollection.AddSingleton(LoggerFactory.Create(builder =>
            {}));

            serviceCollection.AddLogging();

            // Build configuration
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", false)
                .Build();

            // Add access to generic IConfigurationRoot
            serviceCollection.AddSingleton<IConfigurationRoot>(configuration);
            serviceCollection.AddSingleton<IConfiguration>(configuration);

            // Add app
            serviceCollection.AddTransient<Execute>();
            serviceCollection.AddScoped<IRangos, Rangos>();
        }
    }
}
