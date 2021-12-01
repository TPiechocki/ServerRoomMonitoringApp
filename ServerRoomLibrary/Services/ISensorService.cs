using System.Collections.Generic;
using ServerRoomLibrary.Models;

namespace ServerRoomLibrary.Services
{
    public interface ISensorService
    {
        public List<SensorMessage> GetAllSensors();

        public void AddSensor(SensorMessage sensor);
        
        public List<SensorMessage> GetByTypeSensors(string type);

       
    }



}