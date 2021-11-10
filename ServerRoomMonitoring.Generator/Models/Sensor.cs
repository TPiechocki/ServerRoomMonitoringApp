using System;
using Microsoft.Extensions.Configuration;
using ServerRoomMonitoring.Generator.Config;

namespace ServerRoomMonitoring.Generator.Models
{
    public class Sensor
    {
        private int _sensorId { get; set; }
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
            
            return new SensorMessage
            {
                Id = _sensorId,
                Value = sensorValue,
                Unit = unit
                
            };
        }
    }
    // obiekt dto
    public class SensorMessage
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public string Unit { get; set; }
    }
}