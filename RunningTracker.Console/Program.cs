using System;
using RunningTracker.RunningShoes;

namespace RunningTracker.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello World!");

            Shoe s = new Shoe(
                Brand.Brooks, 
                "asdf", 
                1.1, 
                System.DateTime.Now);
        }
    }
}