namespace normari.Models
{
    public class StopWatchModel
    {
        public DateTime StartTime { get; set; }
        public TimeSpan ElapsedTime { get; set; }
        public bool IsRunning { get; set; }
    }
}
