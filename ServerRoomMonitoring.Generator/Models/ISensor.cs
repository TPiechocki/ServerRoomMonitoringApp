using ServerRoomLibrary.Models;
using ServerRoomMonitoring.Generator.Config;

namespace ServerRoomMonitoring.Generator.Models
{
    public interface ISensor
    {
        int _sensorId { get; set; }
        SensorConfig _config { get; }
        SensorMessage GenerateValues();
    }
}