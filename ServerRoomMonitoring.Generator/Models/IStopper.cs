using ServerRoomLibrary.Models;
using ServerRoomMonitoring.Generator.Config;

namespace ServerRoomMonitoring.Generator.Models
{
    public interface IStopper
    {
        bool Stopped { get; set; }
        
    }
}