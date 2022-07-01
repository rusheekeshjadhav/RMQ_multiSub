using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace RabbitMQ_QueueConsumer
{
    public class QueueConsumer
    {
        public static void Consume(IModel channel)
        {
            channel.QueueDeclare("test02",
                durable: true,  // messege will stay until a consumer reads it
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var consumer = new EventingBasicConsumer(channel);  // takes IModel as an argument in a constructor
            consumer.Received += (sender, args) =>
            {
                var body = args.Body.ToArray();    // return byte array of messeges
                var messege = Encoding.UTF8.GetString(body);
                Console.WriteLine(messege); // printing json string as it is
            };

            channel.BasicConsume("test02", true, consumer);
            Console.WriteLine("Consumer started");
            Console.ReadLine();
        }
    }
}
