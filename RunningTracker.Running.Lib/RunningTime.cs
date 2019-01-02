namespace RunningTracker.Running
{
    public enum RunningTimeUnit
    {
        Seconds,
        Minutes,
        Hours,
        Days       
    }

    public class RunningTime
    {
        public RunningTime(
            double time,
            RunningTimeUnit unit)
        {
            Time = time;
            Unit = unit;        
        }

        public double Time { get; }
        public RunningTimeUnit Unit { get; }
    }
}