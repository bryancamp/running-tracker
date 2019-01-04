using System;

namespace RunningTracker.Running
{
    public enum TimeUnit
    {
        Seconds,
        Minutes,
        Hours,
        Days       
    }

    public class Time
    {
        public Time(
            double value,
            TimeUnit unit)
        {
            if (value < 0)
                throw new ArgumentException("Time must be greater than 0.");

            Value = value;
            Unit = unit;        
        }

        public double Value { get; }
        public TimeUnit Unit { get; }
    }
}