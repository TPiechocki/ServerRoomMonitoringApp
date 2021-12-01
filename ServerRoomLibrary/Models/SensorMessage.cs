using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ServerRoomLibrary.Models
{
    public class SensorMessage
    {
        public SensorMessage(int no, string sensorType, int value, string unit, DateTime  date)
        {
            No = no;
           // Id = null;
            SensorType = sensorType;
            Value = value;
            Unit = unit;
            Date = date;
            
            
        }

        [BsonId]
        public ObjectId _id { get; set; }
        public int No { get; set; }
        public string SensorType { get; set; }
        public int Value { get; set; }
        public string Unit { get; set; }
        public DateTime  Date { get; set; }
    }
}