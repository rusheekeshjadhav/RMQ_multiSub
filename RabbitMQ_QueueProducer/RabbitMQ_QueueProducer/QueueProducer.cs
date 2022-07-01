using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ_QueueProducer
{
    public class QueueProducer
    {
        public static void Publish(IModel channel)
        {
            channel.QueueDeclare("test02",
                durable: true,  // messege will stay until a consumer reads it
                exclusive: false,
                autoDelete: false,
                arguments: null);

            while (true)
            {
                var messege = new { Sender = "Producer_01", Messege = "Hello from Producer_01 !!!" };    // annonymus object
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(messege));    // converting JSON object into byte array by JsonConvert

                channel.BasicPublish("", "test02", null, body);
                // currently writing exchange as empty.
                // routing key = name of the queue.
                
                Thread.Sleep(1000);
            }

        }
    }
}
