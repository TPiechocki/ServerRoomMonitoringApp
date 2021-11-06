using System;
using System.Text;
using RabbitMQ.Client;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ServerRoomMonitoringGenerator.Messaging
{
    public class ServerRoomMq
    {

        public void SendMessage<T>(IModel channel, T sensor)
        {
            string sensorData = sensor.ToString();
            var body = Encoding.UTF8.GetBytes(sensorData);
            
            channel.BasicPublish(exchange: "",
                                 routingKey: "server_queue",
                                 basicProperties: null,
                                 body: body);

            Console.WriteLine("{0} has been sent to the queue.", sensorData);
        }
    }
}
