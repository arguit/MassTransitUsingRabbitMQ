using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ServiceA
{
    class Program
    { 
        static void Main(string[] args) =>
            CreateHostBuilder(args).Build().Run();

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {                    
                    services.AddMassTransit(configure =>
                    {                                      
                        configure.UsingRabbitMq((busRegistrationContext, rabbitMqBusFactoryConfigurator) =>
                        {
                            rabbitMqBusFactoryConfigurator.ConfigureEndpoints(busRegistrationContext);
                        });
                    });

                    services.AddMassTransitHostedService();
                    services.AddHostedService<Worker>();
                });
    }
}
