using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using ServerRoomLibrary.Models;
using ServerRoomMonitoring.Generator.Conditions;
using ServerRoomMonitoring.Generator.Messaging;
using ServerRoomMonitoring.Generator.Models;

namespace ServerRoomMonitoring.Generator.Services
{
    public class GeneratorBackgroundService : BackgroundService
    {
        private ISensorQueue _queue;
        private readonly  IStatus _status;
        private IServerRoom _serverRoom;
        
        public GeneratorBackgroundService(ISensorQueue queue, IStatus status, IServerRoom serverRoom)
        {
            _queue = queue;
            _status = status;
            _serverRoom = serverRoom;
        }
        
        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            
            while (!_status.Stopped)
            {
                foreach (var sensor in _serverRoom.Sensors)
                {
                    SensorMessage msg = sensor.GenerateValues();
                    _queue.SendMessage(msg);
                    await Task.Delay(sensor._config.delay);
                }
            }
        }
    }
}