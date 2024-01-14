using RabbitMQ.Client;

namespace rabbitmq_client_provider_pubsub_message
{
    public class RabbitMQService
    {
        private readonly string _hostName = "localhost"; 

        public IConnection GetRabbitMQConnection()
        {
            // using ConnectionFactory class of RabbitMq client provider for connections.
            ConnectionFactory factory = new ConnectionFactory
            {
                // we can set UserName and Password properties if we need security.
                HostName = _hostName
            };

            return factory.CreateConnection();
        }
    }
}
