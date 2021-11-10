using System;
using System.Text;
using RabbitMQ.Client;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using ServerRoomMonitoring.Generator.Config;
using ServerRoomMonitoring.Generator.Models;
using ServerRoomMonitoring.Generator.Messaging;

namespace ServerRoomMonitoring.Generator.Messaging
{
    public class SensorQueue : ISensorQueue
    {
        private readonly string _hostname;
        private readonly string _password;
        private readonly string _queueName;
        private readonly string _username;
        private IConnection _connection;

        public SensorQueue(IOptions<RabbitConfig> rabbitMqOptions)
        {
            _queueName = rabbitMqOptions.Value.QueueName;
            _hostname = rabbitMqOptions.Value.Hostname;
            _username = rabbitMqOptions.Value.UserName;
            _password = rabbitMqOptions.Value.Password;

            CreateConnection();
            CreateQueue();
        }

        private void CreateQueue()
        {
            if (ConnectionExists())
            {
                using (var channel = _connection.CreateModel())
                {
                    channel.QueueDeclare(_queueName,
                        false,
                        false,
                        false,
                        null);
                }
            }
        }

        public void SendMessage(SensorMessage message)
        {
            if (ConnectionExists())
            {
                using (var channel = _connection.CreateModel())
                {
                    var json = JsonConvert.SerializeObject(message);
                    var body = Encoding.UTF8.GetBytes(json);

                    channel.BasicPublish(exchange: "",
                        routingKey: _queueName,
                        basicProperties: null,
                        body: body);
                    
                    Console.WriteLine("{0} has been sent to the queue.", json);
                }
            }
            
        }

        private void CreateConnection()
        {
            try
            {
                var factory = new ConnectionFactory
                {
                    HostName = _hostname,
                    UserName = _username,
                    Password = _password
                };
                _connection = factory.CreateConnection();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Could not create connection: {e.Message}");
            }
        }
        
        private bool ConnectionExists()
        {
            if (_connection != null)
            {
                return true;
            }

            CreateConnection();

            return _connection != null;
        }
    }
}
