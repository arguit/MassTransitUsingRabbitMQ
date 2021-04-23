using MassTransit;
using MassTransit.RabbitMqTransport;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace ServiceA
{
    class Program
    {
        public static RabbitMqHostSettings RabbitMqHostSettings { get; set; }

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
