using System;

namespace RunningTracker.RunningShoes
{
    public class RunningShoeException : System.Exception
    {
        public RunningShoeException(string message)
            : base(message)
            {

            }
    }



    public class Shoe
    {
        public Shoe(
            Brand brand,
            string model,
            double size,
            DateTime releaseDate)      
        {
            Brand = brand;
            Model = model;
            Size = size;
            ReleaseDate = releaseDate;
        }

        public Brand Brand { get; }
        public string Model { get; }
        public double Size { get; }
        public DateTime ReleaseDate { get; }
    }
}