namespace RunningTracker.Running
{
    public enum DistanceUnit
    {
        Kilometers,        
        Meters,
        Miles
    }

    public struct Distance
    {
        public Distance(
            double value, 
            DistanceUnit unit)
        {
            if (value < 0)
                throw new RunningShoes.RunningShoeException("Distance must not be negative.");
                
            Value = value;
            Unit = unit;
        }

        public double Value { get; }
        public DistanceUnit Unit { get; }
    }
}