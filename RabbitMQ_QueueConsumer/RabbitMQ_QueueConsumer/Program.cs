using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Text;

namespace RabbitMQ_QueueConsumer
{
    static class Program
    {
        static void Main(String[] args)
        {
            var factory = new ConnectionFactory
            {
                Uri = new Uri("amqp://guest:guest@localhost:5672")
                // rmq listen on port 5672
                // "amqp://{{username}}:{{password}}@{{host}}:{{port}}"
            };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();   // creates and return a fresh channel, session and model

            QueueConsumer.Consume(channel);
        }
    }
}