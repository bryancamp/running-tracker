using System;
using System.IO;
using System.Collections.Generic;
using RunningTracker.WeatherConditions;
using RunningTracker.Running.Shoes;

namespace RunningTracker.Running.Providers
{
    public interface IProvideRuns
    {
         IEnumerable<Run> GetRuns();
    }

    // TODO: Next on the list, back this by a NoSQL database, 
    //       or .JSON file. We will need a GUI for data entry...
    public class CsvBackedRunProvder: IProvideRuns
    {
        private readonly List<Run> _allRuns;
        private readonly ISerializeRawInputRecords _inputRecordSerializer;
        private readonly IProvideRawInputRecords _rawInputRecordProvider;

        public CsvBackedRunProvder(
            IProvideRawInputRecords rawInputRecordProvider,
            ISerializeRawInputRecords inputRecordSerializer)
        {
            _inputRecordSerializer = inputRecordSerializer;
            _rawInputRecordProvider = rawInputRecordProvider;

            _allRuns = new List<Run>();

            var fileStream = new FileStream("../Data/RunningData.csv", FileMode.Open);
            var reader = new StreamReader(fileStream);
            var rawRecords = _rawInputRecordProvider.GetRecords(reader);
            var typedRecords = _inputRecordSerializer.Serialize(rawRecords);
            foreach(var record in typedRecords)
            {
                _allRuns.Add(FromInputRecord(record));
            }
        }

         public IEnumerable<Run> GetRuns()
         {
             return _allRuns;
         }

        private Run FromInputRecord(TypedInputRecord record)
        {
            var transaction = new Transaction(
                record.ShoePurchasePrice, 
                record.ShoePurchaseDate, 
                record.ShoePurchaseStore);

            var usage = new Usage(
                record.ShoeMileage, 
                record.ShoeUsedDays);                        

            var shoe = new Shoe(
                record.ShoeBrand, 
                record.ShoeModel, 
                record.ShoeSize, 
                record.ShoeReleaseDate, 
                transaction, 
                usage);

            var precipitation = new Precipitation(
                record.PrecipitationType,
                record.PrecipitationUnit,
                record.PrecipitationAmount);

            var temperature = new Temperature(
                record.Temperature, 
                record.TemperatureUnit);

            var run = new Run(
                record.RunDate,
                record.RunDuration,
                new Distance(record.RunDistance, record.RunDistanceUnit),
                record.RunLocation,
                shoe,
                precipitation,
                temperature);

            return run;
        }
    }
}