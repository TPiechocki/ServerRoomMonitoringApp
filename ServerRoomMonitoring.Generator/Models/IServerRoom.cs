using System.Collections.Generic;
using ServerRoomMonitoring.Generator.Models;

namespace ServerRoomMonitoring.Generator.Models
{
    public interface IServerRoom
    {
        public  List<Sensor> Sensors { get; set; }
    }
}