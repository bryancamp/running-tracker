using System.Collections;
using System.Collections.Generic;
using RunningTracker.WeatherConditions;
using RunningTracker.Running;
using RunningTracker.RunningShoes;

namespace RunningTracker.RunningShoes.Providers
{
    public interface IProvideRunningShoes
    {
         IEnumerable<Shoe> GetAllShoes();
    }

    public class CsvBackedRunningShoeProvider : IProvideRunningShoes
    {
        public IEnumerable<Shoe> GetAllShoes()
        {
            Time t = new Time(1, TimeUnit.Hours);
            Distance d = new Distance(7, DistanceUnit.Miles);
            Shoe s = new Shoe(Brand.Brooks, "x10", 10.5, System.DateTime.Today);
            return new List<Shoe>() {s};
        }
    }
}