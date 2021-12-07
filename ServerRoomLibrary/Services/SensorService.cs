using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.CompilerServices;
using ServerRoomLibrary.Models;
using ServerRoomLibrary.Repository;

namespace ServerRoomLibrary.Services
{
    public class SensorService: ISensorService
    {
        private ISensorRepository _sensorRepository;

        public SensorService(ISensorRepository sensorRepository)
        {
            _sensorRepository = sensorRepository;
        }

        public List<Sensor> GetAllSensors()
        {
            return _sensorRepository.GetAllSensors();
        }

        public void AddSensor(Sensor sensor)
        {
           _sensorRepository.AddSensor(sensor);
        }

        public List<Sensor> GetByTypeSensors(string type)
        {
            return _sensorRepository.GetByTypeSensors(type);
        }

        public List<Sensor> GetByAllParamsSensors(int? id, string type, int? value, string unit, DateTime? date)
        {
            
            return _sensorRepository.GetByAllParamsSensors(id, type,  value, unit, date);
        }

        public List<Sensor> GetSortedByAllParamsSensors(int? id, string type, int? value, string unit, DateTime? date,string sortBy, string sortMode)
        {
            return _sensorRepository.GetSortedByAllParamsSensors(id, type, value, unit, date, sortBy, sortMode);
        }

        public List<Sensor> GetSortedByTypeAsc(string type)
        {
            return _sensorRepository.GetSortedByTypeAsc(type);
        }

        public void AddManyDev()
        {
            _sensorRepository.AddManyDev();
        }
        
    }



}