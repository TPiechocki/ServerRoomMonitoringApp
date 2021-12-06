using System.Collections.Generic;
using ServerRoomLibrary.Models;

namespace ServerRoomLibrary.Services
{
    public interface ISensorService
    {
        public List<Sensor> GetAllSensors();

        public void AddSensor(Sensor sensor);
        
        public List<Sensor> GetByTypeSensors(string type);

       
    }



}