using System;
using System.Collections;
using System.Collections.Generic;
using RunningTracker.WeatherConditions;
using RunningTracker.Running.Shoes;

namespace RunningTracker.Running.Providers
{
    public class TypedInputRecord
    {
        public DateTime RunDate { get; internal set; }   
        public TimeSpan RunDuration { get; internal set; }
        public decimal RunDistance { get; internal set; }
        public DistanceUnit RunDistanceUnit { get; internal set; }
        public Location RunLocation { get; internal set; }
        public Brand ShoeBrand { get; internal set; }
        public string ShoeModel { get; internal set; }
        public double ShoeSize { get; internal set; }
        public DateTime ShoeReleaseDate { get; internal set; }
        public decimal ShoeMileage { get; internal set; }
        public int ShoeUsedDays { get; internal set; }
        public decimal ShoePurchasePrice { get; internal set; }
        public DateTime ShoePurchaseDate { get; internal set; }
        public string ShoePurchaseStore { get; internal set; }
        public PrecipitationType PrecipitationType { get; internal set; }
        public decimal PrecipitationAmount { get; internal set; }
        public PrecipitationUnit PrecipitationUnit { get; internal set; }
        public decimal Temperature { get; internal set; }
        public TemperatureUnit TemperatureUnit { get; internal set; }
    }

    public interface ISerializeRawInputRecords
    {
         IEnumerable<TypedInputRecord> Serialize(IEnumerable<RawInputRecord> rawInputRecords);
         TypedInputRecord Serialize(RawInputRecord inputRecord);
    }

    public class RawInputRecordSerializer : ISerializeRawInputRecords
    {
        public IEnumerable<TypedInputRecord> Serialize(IEnumerable<RawInputRecord> rawInputRecords)
        {
            var records = new List<TypedInputRecord>();

            foreach(var rawRecord in rawInputRecords)
            {
                var typedRecord = Serialize(rawRecord);
                records.Add(typedRecord);
            }

            return records;
        }
        
        public TypedInputRecord Serialize(RawInputRecord rawRecord)
        {            
            TypedInputRecord typedRecord = new TypedInputRecord();

            DateTime runDate;
            if (!DateTime.TryParse(rawRecord.Date, out runDate))
                throw new FormatException("Invalid run date.");
            typedRecord.RunDate = runDate;

            TimeSpan runDuration;
            if (!TimeSpan.TryParse(rawRecord.Duration, out runDuration))
                throw new FormatException("Invalid run duration");
            typedRecord.RunDuration = runDuration;

            decimal runDistance;
            if (!decimal.TryParse(rawRecord.Distance, out runDistance))
                throw new FormatException("Invalid run distance");
            typedRecord.RunDistance = runDistance;

            Location runLocation;
            if (!Enum.TryParse(rawRecord.Location, out runLocation))
                throw new FormatException("Invalid location.");
            typedRecord.RunLocation = runLocation;

            PrecipitationType precipitationType;
            if (!Enum.TryParse(rawRecord.PrecipitationType, out precipitationType))
                throw new FormatException("Invalid precipitation type.");
            typedRecord.PrecipitationType = precipitationType;

            PrecipitationUnit precipitationUnit;
            if (!Enum.TryParse(rawRecord.PrecipitationUnit, out precipitationUnit))
                throw new FormatException("Invalid precipitation unit.");
            typedRecord.PrecipitationUnit = precipitationUnit;

            decimal precipitationAmount;
            if (!decimal.TryParse(rawRecord.PrecipitationAmount, out precipitationAmount))
                throw new FormatException("Invalid precipitation amount.");
            typedRecord.PrecipitationAmount = precipitationAmount;

            TemperatureUnit temperatureUnit;
            if (!Enum.TryParse(rawRecord.TemperatureUnit, out temperatureUnit))
                throw new FormatException("Invalid temperature unit.");
            typedRecord.TemperatureUnit = temperatureUnit;

            decimal temperatureValue;
            if (!decimal.TryParse(rawRecord.Temperature, out temperatureValue))
                throw new FormatException("Invalid temperature value.");
            typedRecord.Temperature = temperatureValue;

            Brand shoeBrand;
            if (!Enum.TryParse(rawRecord.ShoeBrand, out shoeBrand))
                throw new FormatException("Invalid shoe brand.");
            typedRecord.ShoeBrand = shoeBrand;

            decimal shoeMileage;
            if (!decimal.TryParse(rawRecord.ShoeMileage, out shoeMileage))
                throw new FormatException("Invalid shoe mileage.");
            typedRecord.ShoeMileage = shoeMileage;

            DateTime shoeReleaseDate;
            if (!DateTime.TryParse(rawRecord.ShoeReleaseDate, out shoeReleaseDate))
                throw new FormatException("Invalid shoe release date.");
            typedRecord.ShoeReleaseDate = shoeReleaseDate;

            double shoeSize;
            if (!double.TryParse(rawRecord.ShoeSize, out shoeSize))
                throw new FormatException("Invalid shoe size.");
            typedRecord.ShoeSize = shoeSize;

            int shoeUsedDays;
            if (!int.TryParse(rawRecord.ShoeUsedDays, out shoeUsedDays))
                throw new FormatException("Invalid shoe used days.");
            typedRecord.ShoeUsedDays = shoeUsedDays;

            DateTime shoePurchaseDate;
            if (!DateTime.TryParse(rawRecord.ShoePurchaseDate, out shoePurchaseDate))
                throw new FormatException("Invalid shoe purchase date.");
            typedRecord.ShoePurchaseDate = shoePurchaseDate;

            decimal shoePurchasePrice;
            if (!decimal.TryParse(rawRecord.ShoePurchasePrice, out shoePurchasePrice))
                throw new FormatException("Invalid shoe purchase price.");
            typedRecord.ShoePurchasePrice = shoePurchasePrice;

            typedRecord.ShoePurchaseStore = rawRecord.ShoePurchaseStore;

            return typedRecord;
        }
    }
}