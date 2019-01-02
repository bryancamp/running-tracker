namespace RunningTracker.Running
{
    public enum RunningDistanceUnit
    {
        Kilometers,        
        Meters,
        Miles
    }

    public struct RunningDistance
    {
        public RunningDistance(
            double distance, 
            RunningDistanceUnit unit)
        {
            Distance = distance;
            Unit = unit;
        }

        public double Distance { get; }
        public RunningDistanceUnit Unit { get; }
    }
}