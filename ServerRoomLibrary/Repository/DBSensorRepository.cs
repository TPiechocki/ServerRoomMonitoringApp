using System;
using System.Collections.Generic;
using ServerRoomLibrary.Models;
using MongoDB.Driver;

namespace ServerRoomLibrary.Repository
{
    public class DBSensorRepository : ISensorRepository
    {
        private readonly IMongoCollection<SensorMessage> _sensors;
        
        public DBSensorRepository(ISensorsDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _sensors = database.GetCollection<SensorMessage>(settings.CollectionName);
            
            var Sensors = new List<SensorMessage>
            {
                new(1, "Temperature", 22, "C",DateTime.Now),
                new(2, "Temperature", 23, "C",DateTime.Now),
                new(3,"Temperature",21,"C",DateTime.Now),
                new(4,"Temperature",20,"C",DateTime.Now),
                new(5,"Temperature",21,"C",DateTime.Now),
                new(6,"Voltage",212,"V",DateTime.Now),
                new(7,"Temperature",22,"C",DateTime.Now),
                new(8,"Temperature",19,"C",DateTime.Now),
                new(9,"Temperature",21,"C",DateTime.Now),
                new(10,"Temperature",20,"C",DateTime.Now),
                new(11,"Temperature",21,"C",DateTime.Now),
                new(12,"Temperature",22,"C",DateTime.Now),
                new(13,"Voltage",213,"V",DateTime.Now),
                new(14,"Voltage",200,"V",DateTime.Now),
            };

            foreach (var var in Sensors)
            {
                _sensors.InsertOne(var);
            }
            
        }

        public List<SensorMessage> GetAllSensors()
        {
            return _sensors.Find(sensor => true).ToList();
        }

        public void AddSensor(SensorMessage sensorMessage)
        {
            _sensors.InsertOne(sensorMessage);
        }

        public List<SensorMessage> GetByTypeSensors(string type)
        {
            throw new System.NotImplementedException();
        }
    }
}