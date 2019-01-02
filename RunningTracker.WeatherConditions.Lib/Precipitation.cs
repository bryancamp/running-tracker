using System;

namespace RunningTracker.WeatherConditions.Lib
{
    public enum PrecipitationType
    {
        None,
        Rain,
        Snow,
        Sleet
    }

    public class Precipitation
    {
        public Precipitation(
            PrecipitationType precipitationType,
            decimal amount = 0)
        {
            PrecipitationType = precipitationType;
            Amount = amount;
        }

        public PrecipitationType PrecipitationType { get; }
        public decimal Amount { get; }
    }
}