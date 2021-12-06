using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using ServerRoomLibrary.Models;
using ServerRoomMonitoring.Generator.Messaging;
using ServerRoomMonitoring.Generator.Models;
using Sensor = ServerRoomMonitoring.Generator.Models.Sensor;

namespace ServerRoomMonitoring.Generator.Services
{
    public class GeneratorBackgroundService : BackgroundService, IGeneratorBackgroundService
    {
        private ISensorQueue _queue;
        private IServerRoom _serverRoom;
        private IStopper _stopper;
        
        public GeneratorBackgroundService(ISensorQueue queue, IServerRoom serverRoom, IStopper stopper)
        {
            _queue = queue;
            _serverRoom = serverRoom;
            _stopper = stopper;
        }

        public async Task DoWork(ISensor sensor, CancellationToken cancellationToken)
        {
            while (!_stopper.Stopped)
            {
                SensorMessage msg = sensor.GenerateValues();
                _queue.SendMessage(msg);
                await Task.Delay(sensor._config.delay);
            }
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            var tasks = new List<Task>();

            foreach (var sensor in _serverRoom.Sensors)
            {
                tasks.Add(Task.Run(() => DoWork(sensor, cancellationToken)));
            }
            await Task.WhenAll(tasks);
        }

       
        public async void Start()
        {
            if (_stopper.Stopped)
            {
                CancellationTokenSource source = new CancellationTokenSource();
                CancellationToken token = source.Token;

                var tasks = new List<Task>();

                foreach (var sensor in _serverRoom.Sensors)
                {
                    tasks.Add(Task.Run(() => DoWork(sensor, token)));
                    await Task.WhenAll(tasks);
                }
            }            
        }
    }
}