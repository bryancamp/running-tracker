using System;
using RunningTracker.RunningShoes;
using RunningTracker.WeatherConditions;

namespace RunningTracker.Running
{
    public class RunningException : System.Exception
    {
        public RunningException(string message)
            : base(message)
            {

            }
    }

    public enum Location
    {
        Outside,
        Treadmill,
        InsideTrack,
        OutsideTrack
    }
    public class Run
    {
        public Run(
            DateTime runDate,
            Time duration,
            Distance distance,
            Location location,
            Shoe shoe,
            Precipitation precipitation)
        {
            if (duration == null)
                throw new ArgumentNullException(nameof(duration));
            if (shoe == null)
                throw new ArgumentNullException(nameof(shoe));

            RunDate = runDate;
            Duration = duration;
            Distance = distance;
            Location = location;
            Shoe = shoe;
            Precipitation = precipitation;
        }
        public DateTime RunDate { get; }
        public Time Duration { get; }
        public Distance Distance { get; }
        public Location Location { get; }
        public Shoe Shoe { get; }
        public Precipitation Precipitation { get; }
    }
}