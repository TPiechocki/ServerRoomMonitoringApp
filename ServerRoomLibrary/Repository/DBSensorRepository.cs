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