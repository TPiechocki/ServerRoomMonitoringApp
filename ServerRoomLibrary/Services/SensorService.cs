using System.Collections.Generic;
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
    }



}