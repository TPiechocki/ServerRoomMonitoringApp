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

        public Sensor(int id, SensorConfig configuration)
        {
            _sensorId = id;
            _config = configuration;
        }
        
        public SensorMessage GenerateValues()
        {
            var random = new Random();
            var sensorValue = random.Next(_config.minRange, _config.maxRange);
            var unit = _config.unit;
            var type = _config.type;           

            return new(_sensorId, type, sensorValue, unit, DateTime.Now);
        }
    }
}