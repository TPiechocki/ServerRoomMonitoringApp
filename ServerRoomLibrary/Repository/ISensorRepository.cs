using System.Collections.Generic;
using ServerRoomLibrary.Models;

namespace ServerRoomLibrary.Repository
{
    public interface ISensorRepository
    {

        public List<SensorMessage> GetAllSensors();

        public void AddSensor(SensorMessage sensorMessage);
        
        public List<SensorMessage> GetByTypeSensors(string type);


    }



}