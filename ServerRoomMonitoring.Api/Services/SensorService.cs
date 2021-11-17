

using System.Collections.Generic;
using ServerRoomMonitoring.Api.Models;
using ServerRoomMonitoring.Api.Repository;

namespace ServerRoomMonitoring.Api.Services
{
    public class SensorService: ISensorService
    {
        private ISensorRepository _sensorRepository;

        public SensorService(ISensorRepository sensorRepository)
        {
            _sensorRepository = sensorRepository;
        }

        public List<SensorMessage> GetAllSensors()
        {
            return _sensorRepository.GetAllSensors();
        }

        public void AddSensor(SensorMessage sensorMessage)
        {
           _sensorRepository.AddSensor(sensorMessage);
        }

        public List<SensorMessage> GetByTypeSensors(string type)
        {
            return _sensorRepository.GetByTypeSensors(type);
        }
    }



}