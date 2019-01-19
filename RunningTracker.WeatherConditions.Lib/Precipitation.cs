using System;

namespace RunningTracker.WeatherConditions
{
    public enum PrecipitationType
    {
        None,
        Rain,
        Snow,
        Sleet
    }

    public enum PrecipitationUnit
    {
        Millimeters,
        Centimeters,
        Inches,
        Feet
    }

    public struct Precipitation
    {
        public Precipitation(
            PrecipitationType type,
            PrecipitationUnit unit,
            decimal amount = 0)
        {
            PrecipitationType = type;
            Unit = unit;
            Amount = amount;
        }
        
        public PrecipitationType PrecipitationType { get; }
        public PrecipitationUnit Unit { get; }
        public decimal Amount { get; }
    }
}