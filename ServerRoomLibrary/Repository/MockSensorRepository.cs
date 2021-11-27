using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using ServerRoomLibrary.Models;

namespace ServerRoomLibrary.Repository
{
    public class MockSensorRepository : ISensorRepository
    {
        private List<SensorMessage> Sensors { get; set; }

        public MockSensorRepository()
        {
            Sensors = new List<SensorMessage>
            {
                new(1, "Temperature", 22, "C",DateTime.Now),
                new(2, "Temperature", 23, "C",DateTime.Now),
                new(2,"Temperature",21,"C",DateTime.Now),
                new(4,"Temperature",20,"C",DateTime.Now),
                new(5,"Temperature",21,"C",DateTime.Now),
                new(6,"Voltage",212,"V",DateTime.Now),
                new(7,"Temperature",22,"C",DateTime.Now),
                new(8,"Temperature",19,"C",DateTime.Now),
                new(9,"Temperature",21,"C",DateTime.Now),
                new(10,"Temperature",20,"C",DateTime.Now),
                new(11,"Temperature",21,"C",DateTime.Now),
                new(12,"Temperature",22,"C",DateTime.Now),
                new(6,"Voltage",213,"V",DateTime.Now),
                new(7,"Voltage",200,"V",DateTime.Now),
            };
        }
        public List<SensorMessage> GetAllSensors()
        {
            return Sensors;
        }

        public void AddSensor(SensorMessage sensorMessage)
        {
            Sensors.Add(sensorMessage);
        }

        public List<SensorMessage> GetByTypeSensors(string type)
        {
            return Sensors.FindAll(x => x.SensorType.Equals(type));
        }
    }
}