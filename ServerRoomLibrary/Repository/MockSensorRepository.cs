using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic;
using ServerRoomLibrary.Models;

namespace ServerRoomLibrary.Repository
{
    public class MockSensorRepository : ISensorRepository
    {
        private List<Sensor> Sensors { get; set; }

        public MockSensorRepository()
        {
            Sensors = new List<Sensor>
            {
                new(1, "Temperature", 22, "C",DateTime.Now),
                new(2, "Temperature", 23, "C",DateTime.Now),
                new(2,"Temperature",21,"C",DateTime.Now),
                new(4,"Temperature",20,"C",DateTime.Now),
                new(5,"Temperature",21,"C",DateTime.Now),
                new(6,"Voltage",212,"V",DateTime.Now),
                new(7,"Temperature",22,"C",DateTime.Now),
                new(8,"Temperature",19,"C",DateTime.Now),
                new(9,"Temperature",21,"C",DateTime.Now),
                new(10,"Temperature",20,"C",DateTime.Now),
                new(11,"Temperature",21,"C",DateTime.Now),
                new(12,"Temperature",22,"C",DateTime.Now),
                new(6,"Voltage",213,"V",DateTime.Now),
                new(7,"Voltage",200,"V",DateTime.Now),
            };
        }
        public List<Sensor> GetAllSensors()
        {
            return Sensors;
        }

        public List<Sensor> GetPageSensors(int elementFrom, int limit)
        {
            throw new NotImplementedException();
        }

        public void AddSensor(Sensor sensor)
        {
            Sensors.Add(sensor);
        }

        public void AddManyDev()
        {
            throw new NotImplementedException();
        }

        public List<Sensor> GetByTypeSensors(string type)
        {
            return Sensors.FindAll(x => x.SensorType.Equals(type));
        }

        public List<Sensor> GetByInstanceSensors(int no)
        {
            throw new NotImplementedException();
        }

        public List<Sensor> GetByDateSensors(DateTime date)
        {
            throw new NotImplementedException();
        }

        public List<Sensor> GetByDateSensors(DateTime dateStart, DateTime dateEnd)
        {
            throw new NotImplementedException();
        }


        public List<Sensor> GetByAllParamsSensors(int? no, string type, int? value, string unit, DateTime? date)
        {
            DateTime daten = (date != null ? date.Value : DateTime.MinValue);
            int non =( no != null ? no.Value : 0);
            int valuen = (value != null ? value.Value : 0);
            
            return Sensors.FindAll(
                sensor =>
               //     (date!= null ? (DateTime.Compare(sensor.Date, date.Value) >= 0 ) : true)
               ///     && (String.IsNullOrEmpty(unit) ? true :sensor.Unit.Equals(unit))
               //     && (value!=null ? sensor.Id.Equals(value.Value): true)
               //     && (String.IsNullOrEmpty(type) ? true :sensor.Unit.Equals(type))
              //      && (no!=null ? sensor.Id.Equals(no.Value) : true)
               ((date!=null && sensor.Date.Equals(daten) ) || date==null) 
               && ((!String.IsNullOrEmpty(unit) && sensor.Unit.Equals(unit) ) || String.IsNullOrEmpty(unit)) 
               && ((value!=null && sensor.Value.Equals(valuen) ) || value==null)
               && ((!String.IsNullOrEmpty(type) && sensor.SensorType.Equals(type) ) || String.IsNullOrEmpty(type))
               && ((no!=null && sensor.Id.Equals(non) ) || no==null)
                
            ).ToList();
            
        }

        public List<Sensor> GetSortedByAllParamsSensors(int? id, string type, int? value, string unit, DateTime? date,string sortBy, string sortMode)
        {
            throw new NotImplementedException();
        }


        public List<Sensor> GetSortedByTypeAsc(string type)
        {
            throw new NotImplementedException();
        }
    }
}