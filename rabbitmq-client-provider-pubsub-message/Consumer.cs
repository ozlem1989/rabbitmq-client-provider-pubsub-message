using RabbitMQ.Client.Events;
using System.Text;

namespace rabbitmq_client_provider_pubsub_message
{
    public class Consumer
    {
        private readonly RabbitMQService _rabbitMQService;

        public Consumer(string queueName)
        {
            _rabbitMQService = new RabbitMQService();

            using (var connection = _rabbitMQService.GetRabbitMQConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    // using EventingBasicConsumer on channel we created.
                    var consumer = new EventingBasicConsumer(channel);

                    // consumer has  a Received event which is always on listening mode. When there is a message on queue, get the message from queue.
                    // RabbitMQ => works on FIFO (First in first out) 
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);
                        Console.WriteLine("{0} queue üzerinden {1} mesajı okundu.", queueName, message);
                    };

                    // autoAck : If yes, after reading the message, it deletes from the queue.  If No; there is no deletion. 
                    channel.BasicConsume(queueName, true, "", false, false, null, consumer);
                    Console.ReadLine();
                }
            }
        }
    }
}
