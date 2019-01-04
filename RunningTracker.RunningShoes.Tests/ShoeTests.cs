using RunningTracker.Running;
using NSubstitute;

namespace Tests
{
    public class ShoeTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ThrowsWhenShoeSizeIsNegative()
        {
            Assert.That(
                new Shoe(Arg.Any<Brand>, Arg.Any<string>, -1, Arg.Any<DateTime>),
                Throws.RunningShoeException);
        }

        [Test]
        public void Test1()
        {
            RunningTracker.Running.Distance d;
            Assert.Pass();
        }
    }
}