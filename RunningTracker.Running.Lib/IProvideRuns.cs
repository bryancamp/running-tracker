using System;
using System.Collections.Generic;
using RunningTracker.WeatherConditions;
using RunningTracker.RunningShoes;

namespace RunningTracker.Running
{
    public interface IProvideRuns
    {
         IEnumerable<Run> GetAllRuns();
         IEnumerable<Run> GetRuns(Location location);
         IEnumerable<Run> GetRuns(Brand brand);         
    }

    public class HardcodedRunProvider : IProvideRuns
    {
        private readonly List<Run> _allRuns;
        private readonly Dictionary<Location, List<Run>> _locationToRuns;
        private readonly Dictionary<Brand, List<Run>> _shoeBrandToRuns;

        public HardcodedRunProvider()
        {
            _allRuns = new List<Run>();
            _locationToRuns = new Dictionary<Location, List<Run>>();
            _shoeBrandToRuns = new Dictionary<Brand, List<Run>>();
        }

        public IEnumerable<Run> GetAllRuns()
        {
            return _allRuns;
        }        

        public IEnumerable<Run> GetRuns(Location location)
        {
            List<Run> runs;
            _locationToRuns.TryGetValue(location, out runs);
            return runs;
        }

        public IEnumerable<Run> GetRuns(Brand brand)
        {
            List<Run> runs;
            _shoeBrandToRuns.TryGetValue(brand, out runs);
            return runs;
        }

        private void Initialize()
        {
            AddRun(
                new Run(
                    new DateTime(2018, 1, 2, 9, 30, 0),
                    new Time(1.5, TimeUnit.Hours), 
                    new Distance(9, DistanceUnit.Miles), 
                    Location.Outside, 
                    null, 
                    new Precipitation(PrecipitationType.None, PrecipitationUnit.Inches)));
        }

        private void AddRun(Run r)
        {
            _allRuns.Add(r);

            List<Run> runs;
            if (!_locationToRuns.TryGetValue(r.Location, out runs))
            {
                runs = new List<Run>();
                _locationToRuns[r.Location] = runs;
            }
            _locationToRuns[r.Location].Add(r);

            if (!_shoeBrandToRuns.TryGetValue(r.Shoe.Brand, out runs))
            {
                runs = new List<Run>();
                _shoeBrandToRuns[r.Shoe.Brand] = runs;
            }
            _shoeBrandToRuns[r.Shoe.Brand].Add(r);
        }
    }
}