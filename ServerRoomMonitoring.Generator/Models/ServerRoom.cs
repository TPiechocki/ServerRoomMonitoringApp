﻿using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using ServerRoomMonitoring.Generator.Config;
using ServerRoomMonitoring.Generator.Models;

namespace ServerRoomMonitoring.Generator.Models
{
    public class ServerRoom: IServerRoom
    {
        public  List<ISensor> Sensors { get; set; }

        public ServerRoom(IConfiguration configuration)
        {
            Sensors = new List<ISensor>
            {
                new Sensor(1, configuration),
                new Sensor(2, configuration),
                new Sensor(3, configuration),
                
            };
        }
    }
}