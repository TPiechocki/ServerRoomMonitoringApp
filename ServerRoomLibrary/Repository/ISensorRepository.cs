using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ServerRoomLibrary.Models;

namespace ServerRoomLibrary.Repository
{
    public interface ISensorRepository
    {

        public List<SensorMessage> GetAllSensors();

        public void AddSensor(SensorMessage sensor);
        
        public List<SensorMessage> GetByTypeSensors(string type);

        public List<SensorMessage> GetByInstanceSensors(int no);


        public List<SensorMessage> GetByDateSensors(DateTime date);
        
        public List<SensorMessage> GetByDateSensors(DateTime dateStart, DateTime dateEnd);



    }



}