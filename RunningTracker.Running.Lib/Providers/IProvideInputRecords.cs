using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace RunningTracker.Running.Providers
{
    public class InputRecord
    {
        public string Date { get; }   
        public string Duration { get; }
        public string Distance { get; }
        public string DistanceUnits { get; }
        public string Location { get; }
        public string ShoeBrand { get; }
        public string ShoeModel { get; }
        public string ShoeSize { get; }
        public string ShoeReleaseDate { get; }
        public string ShoeMileage { get; }
        public string ShoeUsedDays { get; }
        public string PurchasePrice { get; }
        public string PurchaseDate { get; }
        public string PurchaseStore { get; }
        public string PrecipitationType { get; }
        public string PrecipitationAmount { get; }
        public string PrecipitationUnit { get; }
        public string Temperature { get; }
        public string TemperatureUnit { get; }
    }

    // The point of this interface is to decouple:
    // (1) reading of raw data from a csv file or other input source
    // (2) serializing of this raw data into our domain objects 

    public interface IProvideInputRecords
    {
        IEnumerable<InputRecord> GetRecords(Stream inputStream);
        IEnumerable<InputRecord> GetRecords(IEnumerable<Stream> inputStreams);
    }

    // Proprietary csv file format:
    // Date,Time,Distance,DistanceUnits,Location,
    // ShoeBrand,ShoeModel,ShoeSize,ShoeReleaseDate,ShoeMileage,ShoeUsedDays,PurchasePrice,PurchaseDate,PurchaseStore,
    // PrecipitationType,PrecipitationAmount,PrecipitationUnit,Temperature,TemperatureUnit

    public class ProprietaryCsvInputRecordProvider : IProvideInputRecords
    {        
        public IEnumerable<InputRecord> GetRecords(Stream inputStream)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<InputRecord> GetRecords(IEnumerable<Stream> inputStreams)
        {
            List<InputRecord> allRecords = new List<InputRecord>();

            foreach(var stream in inputStreams)
            {
                allRecords.AddRange(GetRecords(stream));
            }

            return allRecords;
        }
    }
}