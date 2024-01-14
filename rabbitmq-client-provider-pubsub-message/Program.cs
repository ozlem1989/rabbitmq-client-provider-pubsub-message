using rabbitmq_client_provider_pubsub_message;

class Program
{
    private static string _queueName = "TESTQUEUE";

    private static Publisher _publisher;
    private static Consumer _consumer;

    private static void Main(string[] args)
    {
        _publisher = new Publisher(_queueName, "Hello RabbitMQ World");
        _consumer = new Consumer(_queueName);
    }
}