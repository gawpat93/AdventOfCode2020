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
        }

        [Test]
        public void SimpleTest()
        {
            var result = Tools.GetAccumulatorValueBeforeInfinitiveLoop(@"Data\simple.dat");
            Assert.AreEqual(5, result);
        }
    }
}