using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using ServerRoomMonitoring.Api.Config;
using ServerRoomMonitoring.Api.Models;
using ServerRoomMonitoring.Api.Services;

namespace ServerRoomMonitoring.Api.Listeners
{
    public class RabbitMqListener: BackgroundService
    {
        private readonly IModel _channel;

        private ISensorService _sensorService;
        public RabbitMqListener(IRabbitConfig rabbitConfig, ISensorService sensorService)
        {
            _sensorService = sensorService;
            var factory = new ConnectionFactory { HostName = rabbitConfig.HostName };
            
            var connection = factory.CreateConnection();
            connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;
            _channel = connection.CreateModel();
            _channel.QueueDeclare(queue: "server_queue", durable: true, exclusive: false, autoDelete: false, arguments: null);
        }

        private void RabbitMQ_ConnectionShutdown(object? sender, ShutdownEventArgs e)
        {
            Console.WriteLine("RabbitMQ_ConnectionShutdown");
        }


        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (ch, ea) =>
            {
                var content = Encoding.UTF8.GetString(ea.Body.ToArray());
                var updateCustomerFullNameModel = JsonConvert.DeserializeObject<SensorMessage>(content);
                Console.WriteLine(" [x] Received {0}", content);
                _sensorService.AddSensor(updateCustomerFullNameModel);

               // var updateCustomerFullNameModel = JsonConvert.DeserializeObject<UpdateCustomerFullNameModel>(content);

              //  HandleMessage(updateCustomerFullNameModel);

                _channel.BasicAck(ea.DeliveryTag, false);
            };
            consumer.Shutdown += OnConsumerShutdown;
            consumer.Registered += OnConsumerRegistered;
            consumer.Unregistered += OnConsumerUnregistered;
            consumer.ConsumerCancelled += OnConsumerCancelled;

            _channel.BasicConsume("server_queue", false, consumer);
            
            return Task.CompletedTask;
        }

        private void OnConsumerCancelled(object? sender, ConsumerEventArgs e)
        {
            Console.WriteLine("OnConsumerCancelled");
        }

        private void OnConsumerUnregistered(object? sender, ConsumerEventArgs e)
        {
            Console.WriteLine("OnConsumerUnregistered");
        }

        private void OnConsumerRegistered(object? sender, ConsumerEventArgs e)
        {
            Console.WriteLine("OnConsumerRegistered");
        }

        private void OnConsumerShutdown(object? sender, ShutdownEventArgs e)
        {
            Console.WriteLine("OnConsumerShutdown");
        }
    }
}