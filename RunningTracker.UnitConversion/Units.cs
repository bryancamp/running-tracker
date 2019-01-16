using System;

namespace RunningTracker.UnitConversion
{
    public enum DistanceUnit
    {
        Centimeter,
        Meter,
        Kilometer,
        Yard,
        Inch,
        Feet,
        Meter,
        Kilometer,
        Mile
    }

    public enum TimeUnit
    {
        Nanoseconds,
        Microsecond,
        Millisecond,
        Second,
        Minute,
        Hour,
        Day,
        Week,
        Month,
        Year        
    }
    
    public class Speed
    {
        public Speed(TimeUnit timeUnit, DistanceUnit distanceUnit, decimal value)
        {
            Time = timeUnit;
            Distance = distanceUnit;
            Value = value;
        }

        public TimeUnit Time { get; }
        public DistanceUnit Distance { get; }
        public decimal Value { get; }
    }
}
