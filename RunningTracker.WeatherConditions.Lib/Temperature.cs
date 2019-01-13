namespace RunningTracker.WeatherConditions
{
    public enum TemperatureUnit
    {
        Celsius,
        Farenheit
    }

    public class Temperature
    {
        public Temperature(
            decimal degrees,
            TemperatureUnit unit)
        {
            Degrees = degrees;
            Unit = unit;
        }

        public decimal Degrees { get; }        
        public TemperatureUnit Unit { get; }
    }
}