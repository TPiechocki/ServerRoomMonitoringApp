using System;
using Microsoft.Extensions.Configuration;
using ServerRoomMonitoring.Generator.Config;
using ServerRoomLibrary.Models;

namespace ServerRoomMonitoring.Generator.Models
{
    public class Sensor : ISensor
    {
        public int _sensorId { get; set; }
        public SensorConfig _config { get; }

        public Sensor(int id, IConfiguration configuration)
        {
            _sensorId = id;
            _config = configuration.GetSection(id.ToString()).Get<SensorConfig>();
        }
        
        public SensorMessage GenerateValues()
        {
            Random random = new Random();
            var sensorValue = random.Next(_config.minRange, _config.maxRange);
            var unit = _config.unit;

            return new(_sensorId, "Temperature", sensorValue, "C", DateTime.Now);
        }
    }
}