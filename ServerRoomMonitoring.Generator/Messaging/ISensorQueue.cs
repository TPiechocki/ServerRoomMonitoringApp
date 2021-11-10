using ServerRoomMonitoring.Generator.Models;

namespace ServerRoomMonitoring.Generator.Messaging
{
    public interface ISensorQueue
    {
        void SendMessage(SensorMessage message);
    }
}