﻿using System.ComponentModel.DataAnnotations;

namespace ServerRoomMonitoring.Generator.Config
{
    public class RabbitConfig
    {
        public string Hostname { get; set; }

        public string QueueName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}