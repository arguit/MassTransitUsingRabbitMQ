namespace MassTransitUsingRabbitMQ.Contracts
{
    public record Message(string Text);

    public interface Message2
    {
        string Text { get; }
    }
}
