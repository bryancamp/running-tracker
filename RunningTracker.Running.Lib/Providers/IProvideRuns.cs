using System;
using System.IO;
using System.Collections.Generic;
using RunningTracker.WeatherConditions;
using RunningTracker.Running.Shoes;

namespace RunningTracker.Running
{
    public interface IProvideRuns
    {
         IEnumerable<Run> GetAllRuns();
         IEnumerable<Run> GetRuns(Location location);
         IEnumerable<Run> GetRuns(Brand brand);         
    }

    // TODO: Next on the list, back this by a NoSQL database, 
    //       or .JSON file. We will need a GUI for data entry...
    public class CsvBackedRunProvder: IProvideRuns
    {
        private readonly List<Run> _allRuns;
        private readonly Dictionary<Location, List<Run>> _locationToRuns;
        private readonly Dictionary<Brand, List<Run>> _shoeBrandToRuns;

        public CsvBackedRunProvder()
        {
            _allRuns = new List<Run>();
            _locationToRuns = new Dictionary<Location, List<Run>>();
            _shoeBrandToRuns = new Dictionary<Brand, List<Run>>();

            ParseFile("../Data/RunningData.csv");
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

         private void ParseFile(string filePath)
         {
            var fileStream = new FileStream(filePath, FileMode.Open);
            using (StreamReader reader = new StreamReader(fileStream))
            {
                // Ignore header
                var lineInFile = reader.ReadLine();

                while((lineInFile = reader.ReadLine()) != null)
                {
                    var run = FromLineInFile(lineInFile);

                    _allRuns.Add(run);

                    List<Run> locations;
                    if (!_locationToRuns.TryGetValue(run.Location, out locations))
                    {
                        locations = new List<Run>();
                        _locationToRuns[run.Location] = locations;
                    }
                    locations.Add(run);

                    List<Run> brands;
                    if (!_shoeBrandToRuns.TryGetValue(run.Shoe.Brand, out brands))
                    {
                        brands = new List<Run>();
                        _shoeBrandToRuns[run.Shoe.Brand] = brands;
                    }
                    brands.Add(run);
                }
            }
        }

        private Run FromLineInFile(string lineInFile)
        {
            var tokens = lineInFile.Split(',');

            Location runLocation;
            if (!Enum.TryParse(tokens[4], out runLocation))
                throw new FormatException("Invalid location.");

            Brand brand;
            if (!Enum.TryParse(tokens[5], out brand))
                throw new FormatException("Invalid shoe brand.");

            PrecipitationType precipitationType;
            if (!Enum.TryParse(tokens[14], out precipitationType))
                throw new FormatException("Invalid precipitation type.");

            PrecipitationUnit precipitationUnit;
            if (!Enum.TryParse(tokens[16], out precipitationUnit))
                throw new FormatException("Invalid precipitation unit.");

            TemperatureUnit temperatureUnit;
            if (!Enum.TryParse(tokens[18], out temperatureUnit))
                throw new FormatException("Invalid temperature unit.");

            var transaction = new Transaction(Convert.ToDecimal(tokens[11]), DateTime.Parse(tokens[12]), tokens[13]);
            var usage = new Usage(Convert.ToDouble(tokens[9]), Convert.ToInt32(tokens[10]));                        
            var shoe = new Shoe(brand, tokens[6], Convert.ToDouble(tokens[7]), DateTime.Parse(tokens[8]), transaction, usage);
            var precipitation = new Precipitation(precipitationType, precipitationUnit, Convert.ToDouble(tokens[15]));
            var temperature = new Temperature(Convert.ToDecimal(tokens[17]), temperatureUnit);

            var run = new Run(
                DateTime.Parse(tokens[0]),
                new Time(TimeSpan.Parse(tokens[1]).TotalMinutes, TimeUnit.Minutes),
                new Distance(Convert.ToDouble(tokens[2]), DistanceUnit.Miles),
                runLocation,
                shoe,
                precipitation,
                temperature);

            return run;
        }
    }

    public class NoSqlBackedRunProvder: IProvideRuns
    {
         public IEnumerable<Run> GetAllRuns()
         {
             throw new NotImplementedException();
         }

         public IEnumerable<Run> GetRuns(Location location)
         {
             throw new NotImplementedException();
         }

         public IEnumerable<Run> GetRuns(Brand brand)
         {
             throw new NotImplementedException();
         }
    }
}