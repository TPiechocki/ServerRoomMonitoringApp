using System;
using System.Collections.Generic;
using ServerRoomLibrary.Models;
using MongoDB.Driver;

namespace ServerRoomLibrary.Repository
{
    public class DBSensorRepository : ISensorRepository
    {
        private readonly IMongoCollection<Sensor> _sensors;
        
        public DBSensorRepository(ISensorsDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _sensors = database.GetCollection<Sensor>(settings.CollectionName);
           
            //bool dev = true;
            //if (dev)
            //{
            //    var sensors = new List<Sensor>
            //    {
            //        new(1, "Temperature", 22, "C",DateTime.Now),
            //        new(1, "Temperature", 34, "F",DateTime.UtcNow),
            //        new(1,"Temperature",21,"C",DateTime.Now),
            //        new(4,"Temperature",20,"C",DateTime.Now),
            //        new(5,"Temperature",21,"C",DateTime.Now),
            //        new(6,"Voltage",212,"V",DateTime.MaxValue),
            //        new(7,"Temperature",22,"C",DateTime.Today),
            //        new(8,"Temperature",19,"C",DateTime.Now),
            //        new(9,"Temperature",50,"F",DateTime.Now),
            //        new(10,"Temperature",20,"C",DateTime.Now),
            //        new(10,"Temperature",21,"C",DateTime.MinValue),
            //        new(11,"Temperature",-10,"C",DateTime.Now),
            //        new(11,"Voltage",213,"V",DateTime.Now),
            //        new(14,"Voltage",200,"V",DateTime.Now),
            //    };
            //    foreach (var var in sensors)
            //    {
            //        _sensors.InsertOne(var);
            //    }
            //}
        }

        public List<Sensor> GetAllSensors()
        {
            return GetPageSensors(0, 10);
        }
        public List<Sensor> GetPageSensors(int elementFrom,int limit)
        {
            return _sensors.Find(sensor => true).Skip(elementFrom)
                .Limit(limit).ToList();
        }

        public void AddSensor(Sensor sensor)
        {
            _sensors.InsertOne(sensor);
        }

        public void AddManyDev()
        {
            var sensors = new List<Sensor>
            {
                new(1, "Temperature", 22, "C",DateTime.Now),
                new(2, "Temperature", 34, "F",DateTime.UtcNow),
                new(3,"Temperature",21,"C",DateTime.Now),
                new(4,"Temperature",20,"C",DateTime.Now),
                new(5,"Temperature",21,"C",DateTime.Now),
                new(6,"Voltage",212,"V",DateTime.MaxValue),
                new(7,"Temperature",22,"C",DateTime.Today),
                new(8,"Temperature",19,"C",DateTime.Now),
                new(9,"Temperature",50,"F",DateTime.Now),
                new(10,"Temperature",20,"C",DateTime.Now),
                new(11,"Temperature",21,"C",DateTime.MinValue),
                new(12,"Temperature",-10,"C",DateTime.Now),
                new(13,"Voltage",213,"V",DateTime.Now),
                new(14,"Voltage",200,"V",DateTime.Now),
            };
            foreach (var var in sensors)
            {
                _sensors.InsertOne(var);
            }
        }

        public List<Sensor> GetByTypeSensors(string type)
        {
            return _sensors.Find(x => x.SensorType.Equals(type)).ToList();
        }
        
        public List<Sensor> GetByInstanceSensors(int no)
        {
            return _sensors.Find(sensor => true).ToList();
        }
        
        public List<Sensor> GetByDateSensors(DateTime date)
        {
            return _sensors.Find(sensor => DateTime.Compare(sensor.Date,date) >= 0).ToList();
        }

        public List<Sensor> GetByDateSensors(DateTime dateStart, DateTime dateEnd)
        {
            return _sensors.Find(sensor =>
                DateTime.Compare(sensor.Date, dateStart) >= 0 && DateTime.Compare(sensor.Date, dateEnd) <= 0).ToList();
        }
        
        public List<Sensor> GetByAllParamsSensors(int? no, string type, int? value, string unit, DateTime? date)
        {
            DateTime daten = (date != null ? date.Value : DateTime.MinValue);
            int non =( no != null ? no.Value : 0);
            int valuen = (value != null ? value.Value : 0);


            return _sensors.Find(
                sensor => 
               // (date!=null && sensor.Date.Equals(daten) )
               // && (!String.IsNullOrEmpty(unit) && sensor.Unit.Equals(unit) )
               // && (value!=null && sensor.Value.Equals(valuen) )
               // && (!String.IsNullOrEmpty(type) && sensor.SensorType.Equals(type) )
               // && (no!=null && sensor.Id.Equals(non) )
                
               ((date!=null && sensor.Date.Equals(daten) ) || date==null) 
               && ((!String.IsNullOrEmpty(unit) && sensor.Unit.Equals(unit) ) || String.IsNullOrEmpty(unit)) 
               && ((value!=null && sensor.Value.Equals(valuen) ) || value==null)
               && ((!String.IsNullOrEmpty(type) && sensor.SensorType.Equals(type) ) || String.IsNullOrEmpty(type))
               && ((no!=null && sensor.Id.Equals(non) ) || no==null)
                
                
                ).ToList();
        }
        
        public List<Sensor> GetSortedByAllParamsSensors(int? id, string type, int? value, string unit, DateTime? date,string sortBy, string sortMode)
        {
            bool sortAsc = !sortMode?.Equals("desc") ?? true;

            DateTime daten = (date != null ? date.Value : DateTime.MinValue);
            int non =( id != null ? id.Value : 0);
            int valuen = (value != null ? value.Value : 0);
           

            var quer = _sensors.Find(
                sensor =>
                    ((date != null && sensor.Date.Equals(daten)) || date == null)
                    && ((!String.IsNullOrEmpty(unit) && sensor.Unit.Equals(unit)) || String.IsNullOrEmpty(unit))
                    && ((value != null && sensor.Value.Equals(valuen)) || value == null)
                    && ((!String.IsNullOrEmpty(type) && sensor.SensorType.Equals(type)) || String.IsNullOrEmpty(type))
                    && ((id != null && sensor.Id.Equals(non)) || id == null)
            );

            if (sortBy != null)
            {
                switch (sortBy)
                {
                    case "id":
                        if (sortAsc is true)
                        {
                            quer = quer.SortBy(sensor => sensor.Id);
                        }
                        else
                        {
                            quer = quer.SortByDescending(sensor => sensor.Id);
                        }
                    
                        break;
                    case "type":
                        if (sortAsc is true)
                        {
                            quer = quer.SortBy(sensor => sensor.SensorType);
                        }
                        else
                        {
                            quer = quer.SortByDescending(sensor => sensor.SensorType);
                        }
                    
                        break;
                    case "value":
                        if (sortAsc is true)
                        {
                            quer = quer.SortBy(sensor => sensor.Value);
                        }
                        else
                        {
                            quer = quer.SortByDescending(sensor => sensor.Value);
                        }
                    
                        break;
                    case "unit":
                    
                        if (sortAsc is true)
                        {
                            quer = quer.SortBy(sensor => sensor.Unit);
                        }
                        else
                        {
                            quer = quer.SortByDescending(sensor => sensor.Unit);
                        }

                        break;
                    case "date":
                        if (sortAsc is true)
                        {
                            quer = quer.SortBy(sensor => sensor.Date);
                        }
                        else
                        {
                            quer = quer.SortByDescending(sensor => sensor.Date);
                        }
                    
                        break;
                }
            }
            return quer.ToList();
        }
        
        
        
        public List<Sensor> GetSortedByTypeAsc(string type)
        {
            return _sensors.Find(sensor => (!String.IsNullOrEmpty(type) && sensor.SensorType.Equals(type) )).SortBy(sensor => sensor.SensorType).ToList();
        }
        
        
    }
}