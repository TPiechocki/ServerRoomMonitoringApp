using System;

namespace ServerRoomLibrary.Models
{
    public class Sensor
    {
      
        public int Id { get; set; }
        public string SensorType { get; set; }
        public int Value { get; set; }
        public string Unit { get; set; }
        public DateTime  Date { get; set; }
    }
}