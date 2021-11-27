using ServerRoomLibrary.Models;

namespace ServerRoomMonitoring.Generator.Messaging
{
    public interface ISensorQueue
    {
        void SendMessage(SensorMessage message);
    }
}