using System;

namespace ServerRoomMonitoringGenerator.Models
{
    public class TemperatureSensor
    {
        public int Temperature { get; set; }
        public string Unit { get; set; }

        public void generateValues()
        {
            Random random = new Random();
            Temperature = random.Next(-20,40);
            Unit = "Celcius";
        }
    }
}