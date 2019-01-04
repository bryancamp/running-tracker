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
            Time time,
            Distance distance,
            Location location,
            Shoe shoe,
            Precipitation precipitation)
        {
            if (time == null)
                throw new ArgumentNullException(nameof(time));
            if (shoe == null)
                throw new ArgumentNullException(nameof(shoe));

            Time = time;
            Distance = distance;
            Location = location;
            Shoe = shoe;
            Precipitation = precipitation;
        }

        public Time Time { get; }
        public Distance Distance { get; }
        public Location Location { get; }
        public Shoe Shoe { get; }
        public Precipitation Precipitation { get; }
    }
}