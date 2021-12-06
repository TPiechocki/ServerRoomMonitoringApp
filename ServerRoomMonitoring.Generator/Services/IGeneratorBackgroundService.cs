using ServerRoomMonitoring.Generator.Messaging;
using ServerRoomMonitoring.Generator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ServerRoomMonitoring.Generator.Services
{
    public interface IGeneratorBackgroundService
    {


        public Task DoWork(ISensor sensor, CancellationToken cancellationToken);

        public void Start();
    }
}
