using System;

namespace ServerRoomMonitoring.Api.Models
{
    public class SensorMessage
    {
        public SensorMessage(int id, string sensorType, int value, string unit)
        {
            Id = id;
            SensorType = sensorType;
            Value = value;
            Unit = unit;
        }

        public int Id { get; set; }
        public string SensorType { get; set; }
        public int Value { get; set; }
        public string Unit { get; set; }
    }
}