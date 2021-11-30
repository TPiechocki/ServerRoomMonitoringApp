namespace ServerRoomMonitoring.Generator.Models
{
    public class Stopper : IStopper
    {
        public bool Stopped { get; set; }

        public Stopper()
        {
            Stopped = false;
        }
      
    }
}