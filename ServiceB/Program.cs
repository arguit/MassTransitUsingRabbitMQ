using MassTransitUsingRabbitMQ.Consumers;
using MassTransit;
using Microsoft.Extensions.Hosting;

namespace MassTransitUsingRabbitMQ.ServiceB
{
    class Program
    {
        static void Main(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostBuilderContext, services) =>
                {
                    services.AddMassTransit(configure =>
                    {
                        configure.AddConsumer<MessageConsumer>();
                        
                        configure.UsingRabbitMq((busRegistrationContext, rabbitMqBusFactoryConfigurator) =>
                        {                            
                            rabbitMqBusFactoryConfigurator.ConfigureEndpoints(busRegistrationContext);
                        });
                    });

                    services.AddMassTransitHostedService();                    
                })
               .Build()
               .Run();
    }
}
