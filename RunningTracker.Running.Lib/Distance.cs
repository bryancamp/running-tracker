using RunningTracker;

namespace RunningTracker.Running
{
    public enum DistanceUnit
    {
        Kilometers,        
        Meters,
        Miles
    }

    public class Distance
    {
        public Distance(
            decimal value, 
            DistanceUnit unit)
        {
            if (value < 0)
                throw new RunningException("Distance must not be negative.");
                
            Value = value;
            Unit = unit;
        }

        public decimal Value { get; }
        public DistanceUnit Unit { get; }
    }
}