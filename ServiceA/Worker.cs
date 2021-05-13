using MassTransitUsingRabbitMQ.Contracts;
using MassTransit;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace MassTransitUsingRabbitMQ.ServiceA
{
    public class Worker 
        : BackgroundService
    {
        readonly ILogger logger;

        readonly IBus bus;

        public Worker(ILogger<Worker> logger, IBus bus)
        {
            this.logger = logger;
            this.bus = bus;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await bus.Publish(new Message($"The time is {DateTimeOffset.Now}"));

                await bus.Publish<Message2>(new {
                    Text = "aaa",
                    Neee = "bbb"
                });
                
                logger.LogInformation($"Message has been send.");

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
