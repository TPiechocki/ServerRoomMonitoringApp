using System;
using RabbitMQ.Client;
using ServerRoomMonitoringGenerator.Messaging;
using ServerRoomMonitoringGenerator.Models;

namespace ServerRoomMonitoring.Generator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serverRoomMqUserName = "guest";
            var serverRoomMqPassword = "guest";
            var serverRoomMqServer = "localhost";
            var port = 5672;
            
            var mq = new ServerRoomMq();
            
            var factory = new ConnectionFactory()
            {
                HostName = serverRoomMqServer, Port = port, UserName = serverRoomMqUserName,
                Password = serverRoomMqPassword
            };
            
            var delay = 2000;
            
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {

                channel.QueueDeclare(queue: "server_queue",
                    durable: true,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                var tempSensor = new TemperatureSensor();

                while (true)
                {
                    tempSensor.generateValues();
                    mq.SendMessage(channel, tempSensor);
                    System.Threading.Thread.Sleep(delay);
                }
            }

        }
    }
}
