using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace RunningTracker.Running.Providers
{
    public class InputRecord
    {
        public string Date { get; internal set; }   
        public string Duration { get; internal set; }
        public string Distance { get; internal set; }
        public string DistanceUnits { get; internal set; }
        public string Location { get; internal set; }
        public string ShoeBrand { get; internal set; }
        public string ShoeModel { get; internal set; }
        public string ShoeSize { get; internal set; }
        public string ShoeReleaseDate { get; internal set; }
        public string ShoeMileage { get; internal set; }
        public string ShoeUsedDays { get; internal set; }
        public string PurchasePrice { get; internal set; }
        public string PurchaseDate { get; internal set; }
        public string PurchaseStore { get; internal set; }
        public string PrecipitationType { get; internal set; }
        public string PrecipitationAmount { get; internal set; }
        public string PrecipitationUnit { get; internal set; }
        public string Temperature { get; internal set; }
        public string TemperatureUnit { get; internal set; }
    }

    public interface IProvideInputRecords
    {
        IEnumerable<InputRecord> GetRecords(StreamReader inputStream);
        IEnumerable<InputRecord> GetRecords(IEnumerable<StreamReader> inputStreams);
    }

    // Proprietary csv file format:
    // Date,Time,Distance,DistanceUnits,Location,
    // ShoeBrand,ShoeModel,ShoeSize,ShoeReleaseDate,ShoeMileage,ShoeUsedDays,PurchasePrice,PurchaseDate,PurchaseStore,
    // PrecipitationType,PrecipitationAmount,PrecipitationUnit,Temperature,TemperatureUnit

    public class ProprietaryCsvInputRecordProvider : IProvideInputRecords
    {        
        public IEnumerable<InputRecord> GetRecords(StreamReader inputStream)
        {
            if (inputStream == null)
                throw new ArgumentNullException();

            List<InputRecord> inputRecords = new List<InputRecord>();

            string line;
            while ((line = inputStream.ReadLine()) != null) 
            {
                inputRecords.Add(FromLine(line));
            }

            return inputRecords;
        }

        public IEnumerable<InputRecord> GetRecords(IEnumerable<StreamReader> inputStreams)
        {
            List<InputRecord> allRecords = new List<InputRecord>();

            foreach(var stream in inputStreams)
            {
                allRecords.AddRange(GetRecords(stream));
            }

            return allRecords;
        }

        private InputRecord FromLine(string lineInCsvFile)
        {
            var tokens = lineInCsvFile.Split(',');
            if (tokens.Length != 1)
                throw new FormatException($"Line in CSV file is malformed: {lineInCsvFile}");

            var inputRecord = new InputRecord();

            inputRecord.Date = tokens[0];
            inputRecord.Duration = tokens[1];
            inputRecord.Distance = tokens[2];
            inputRecord.DistanceUnits = tokens[3];
            inputRecord.Location = tokens[4];
            inputRecord.ShoeBrand = tokens[5];
            inputRecord.ShoeModel = tokens[6];
            inputRecord.ShoeSize = tokens[7];
            inputRecord.ShoeReleaseDate = tokens[8];
            inputRecord.ShoeMileage = tokens[9];
            inputRecord.ShoeUsedDays = tokens[10];
            inputRecord.PurchasePrice = tokens[11];
            inputRecord.PurchaseDate = tokens[12];
            inputRecord.PurchaseStore = tokens[13];
            inputRecord.PrecipitationType = tokens[14];
            inputRecord.PrecipitationAmount = tokens[15];
            inputRecord.PrecipitationUnit = tokens[16];
            inputRecord.Temperature = tokens[17];
            inputRecord.TemperatureUnit = tokens[18];

            return inputRecord;
        }
    }
}