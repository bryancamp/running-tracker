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

    public interface ICompareSpeed
    {
        public Speed GetFastest(Speed s1, Speed s2);
        public Speed GetFastest(IEnumerable<Speed> speeds);

        public Speed GetSlowest(Speed s1, Speed s2);
        public Speed GetSlowest(IEnumerable<Speed> speeds);

        public void SortAscending(ref IEnumerable<Speed> collectionToSort)
    }
}
