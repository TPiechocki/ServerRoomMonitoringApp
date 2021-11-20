using System.Collections.Generic;
using ServerRoomMonitoring.Web.Models;

namespace ServerRoomMonitoring.Api.Repository
{
    public class MockSensorRepository : ISensorRepository
    {
        private List<SensorMessage> Sensors { get; set; }

        public MockSensorRepository()
        {
            Sensors = new List<SensorMessage>
            {
                new SensorMessage(1, "Temperature", 22, "C"),
                new SensorMessage(2, "Temperature", 23, "C"),
                new SensorMessage(2,"Temperature",21,"C"),
                new SensorMessage(4,"Temperature",20,"C"),
                new SensorMessage(5,"Temperature",21,"C"),
                new SensorMessage(6,"Voltage",212,"V"),
                new SensorMessage(7,"Temperature",22,"C"),
                new SensorMessage(8,"Temperature",19,"C"),
                new SensorMessage(9,"Temperature",21,"C"),
                new SensorMessage(10,"Temperature",20,"C"),
                new SensorMessage(11,"Temperature",21,"C"),
                new SensorMessage(12,"Temperature",22,"C"),
                new SensorMessage(6,"Voltage",213,"V"),
                new SensorMessage(7,"Voltage",200,"V"),
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