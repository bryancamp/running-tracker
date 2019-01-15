using System;
using NUnit;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
//using RunningTracker.Running.Shoes;

namespace RunningTracker.Running.Tests
{
    public class DistanceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ThrowsWhenShoeSizeIsNegative()
        {
            // Assert.That(
            //     new Shoe(Arg.Any<Brand>, Arg.Any<string>, -1, Arg.Any<DateTime>),
            //     Throws.RunningShoeException);
        }

        // [Test]
        // public void Test1()
        // {
        //     RunningTracker.Running.Distance d;
        //     Assert.Pass();
        // }
    }
}