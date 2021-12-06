using System;
using System.Collections.Generic;
using ServerRoomLibrary.Models;

namespace ServerRoomLibrary.Services
{
    public interface ISensorService
    {
        public List<Sensor> GetAllSensors();

        public void AddSensor(Sensor sensor);
        
        public List<Sensor> GetByTypeSensors(string type);

        public List<Sensor> GetByAllParamsSensors(int? id, string type, int? value, string unit, DateTime? date);


    }



}