using System.Text;

namespace rabbitmq_client_provider_pubsub_message
{
    public class Publisher
    {
        private readonly RabbitMQService _rabbitMQService;

        public Publisher(string queueName, string message)
        {
            _rabbitMQService = new RabbitMQService();

            using (var connection = _rabbitMQService.GetRabbitMQConnection())
            {
                // creating a new channel : 
                using (var channel = connection.CreateModel())
                {
                    // creating a queue. 
                    // durable : if yes, queue worked on in-memory, starts to work on disk. In case of RabbitMq server stops, queue is on disk, not losing queue. 
                    channel.QueueDeclare(queueName, false, false, false, null);

                    // sending message to the queue
                    channel.BasicPublish("", queueName, false, null, Encoding.UTF8.GetBytes(message));

                    Console.WriteLine("{0} queue'su üzerine {1} mesajı yazıldı.", queueName, message);
                }
            }
        }
    }
}
