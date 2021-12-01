using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ServerRoomLibrary.Models
{
    public class Sensor
    {
      
        [BsonId]
        public ObjectId _id { get; set; }
        public string SensorType { get; set; }
        public int Value { get; set; }
        public string Unit { get; set; }
        public DateTime  Date { get; set; }
    }
}