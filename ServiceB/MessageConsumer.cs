using Contracts;
using MassTransit;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Consumers
{
    public class MessageConsumer
        : IConsumer<Message>
    {
        readonly ILogger logger;

        public MessageConsumer(ILogger<MessageConsumer> logger)
        {
            this.logger = logger;
        }

        public Task Consume(ConsumeContext<Message> context)
        {
            logger.LogInformation($"Recived Text: {context.Message.Text}");
            return Task.CompletedTask;
        }
    }
}