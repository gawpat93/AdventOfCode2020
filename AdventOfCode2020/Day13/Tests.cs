using NUnit.Framework;

namespace Day13
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void FinalTest()
        {
            var result = Tools.GetResultPart1(@"Data\input.dat");
            Assert.AreEqual(3789, result);

            var result2 = Tools.GetResultPart2(@"Data\input.dat");
            Assert.AreEqual(0, result2);
        }

        [Test]
        public void SimpleTest()
        {
            var result = Tools.GetResultPart1(@"Data\simple.dat");
            Assert.AreEqual(295, result);

            var result2 = Tools.GetResultPart2(@"Data\simple.dat");
            Assert.AreEqual(0, result2);
        }
    }
}