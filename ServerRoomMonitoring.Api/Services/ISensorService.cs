

using System.Collections.Generic;
using ServerRoomMonitoring.Api.Models;

namespace ServerRoomMonitoring.Api.Services
{
    public interface ISensorService
    {
        public List<SensorMessage> GetAllSensors();

        public void AddSensor(SensorMessage sensorMessage);
        
        public List<SensorMessage> GetByTypeSensors(string type);

       
    }



}