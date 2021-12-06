using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ServerRoomMonitoring.Generator.Config;
using System.Collections.Generic;
using System.IO;

namespace ServerRoomMonitoring.Generator.Models
{
    public class ServerRoom: IServerRoom
    {
        private readonly ILogger<ServerRoom> _logger;

        public List<ISensor> Sensors { get; set; }

        public ServerRoom(ILogger<ServerRoom> logger)
        {
            _logger = logger;

            var configs = JsonConvert.DeserializeObject<List<SensorConfig>>(File.ReadAllText("ServerRoom.json"));
            Sensors = SensorsFromConfig(configs);
        }

        public void UpdateSensors(IReadOnlyList<SensorConfig> configs)
        {
            Sensors = SensorsFromConfig(configs);
        }

        private List<ISensor> SensorsFromConfig(IReadOnlyList<SensorConfig> configs)
        {
            var Sensors = new List<ISensor>();
            for (int i = 0; i < configs.Count; i++)
            {
                Sensors.Add(new Sensor(i, configs[i]));
            }
            _logger.LogInformation("Setting new sensors");
            return Sensors;
        }
    }
}