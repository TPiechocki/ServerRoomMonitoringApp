using ServerRoomMonitoring.Generator.Config;
using System.Collections.Generic;

namespace ServerRoomMonitoring.Generator.Models
{
    public interface IServerRoom
    {
        public  List<ISensor> Sensors { get; }

        void UpdateSensors(IReadOnlyList<SensorConfig> configs);
    }
}