using System;
using System.Collections.Generic;
using ServerRoomMonitoring.Api.Models;

namespace ServerRoomMonitoring.Api.Repository
{
    public interface ISensorRepository
    {

        public List<SensorMessage> GetAllSensors();

        public void AddSensor(SensorMessage sensorMessage);
        
        public List<SensorMessage> GetByTypeSensors(string type);


    }



}