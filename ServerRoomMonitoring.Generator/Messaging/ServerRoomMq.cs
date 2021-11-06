using System;
using System.Text;
using RabbitMQ.Client;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace ServerRoomMonitoringGenerator.Messaging
{
    public class ServerRoomMq
    {

        public void SendMessage<T>(IModel channel, T sensor)
        {
            var sensorData = JsonConvert.SerializeObject(sensor);
            var body = Encoding.UTF8.GetBytes(sensorData);
            
            channel.BasicPublish(exchange: "",
                                 routingKey: "server_queue",
                                 basicProperties: null,
                                 body: body);

            Console.WriteLine("{0} has been sent to the queue.", sensorData);
        }
    }
}
