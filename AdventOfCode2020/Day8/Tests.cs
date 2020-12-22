using NUnit.Framework;
namespace Day8
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void FinalTest()
        {
            var result = Tools.GetAccumulatorValueBeforeInfinitiveLoop(@"Data\input.dat");
            Assert.AreEqual(1753, result);

            var result1 = Tools.GetAccumulatorValue(@"Data\input.dat");
            Assert.AreEqual(733, result1);
        }

        [Test]
        public void SimpleTest()
        {
            var result = Tools.GetAccumulatorValueBeforeInfinitiveLoop(@"Data\simple.dat");
            Assert.AreEqual(5, result);

            var result1 = Tools.GetAccumulatorValue(@"Data\simple.dat");
            Assert.AreEqual(8, result1);
        }
    }
}