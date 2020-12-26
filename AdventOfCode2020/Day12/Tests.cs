using NUnit.Framework;

namespace Day12
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void FinalTest()
        {
            var result = Tools.GetResultPart1(@"Data\input.dat");
            Assert.AreEqual(636, result);

            var result2 = Tools.GetResultPart2(@"Data\input.dat");
            Assert.AreEqual(26841, result2);
        }

        [Test]
        public void SimpleTest()
        {
            var result = Tools.GetResultPart1(@"Data\simple.dat");
            Assert.AreEqual(25, result);

            var result2 = Tools.GetResultPart2(@"Data\simple.dat");
            Assert.AreEqual(286, result2);
        }
    }
}