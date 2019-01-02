using System;
using RunningTracker.RunningShoes;
using RunningTracker.WeatherConditions;

namespace RunningTracker.Running
{
    public enum RunningLocation
    {
        Outside,
        Treadmill,
        InsideTrack,
        OutsideTrack
    }
    public class Run
    {
        public Run(
            RunningTime time,
            RunningDistance distance,
            RunningLocation location,
            Shoe shoe,
            Precipitation precipitation)
        {
            Time = time;
            Distance = distance;
            Location = location;
            Shoe = shoe;
            Precipitation = precipitation;
        }

        public RunningTime Time { get; }
        public RunningDistance Distance { get; }
        public RunningLocation Location { get; }
        public Shoe Shoe { get; }
        public Precipitation Precipitation { get; }
    }
}