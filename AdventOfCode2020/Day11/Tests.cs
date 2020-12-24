using NUnit.Framework;

namespace Day11
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void FinalTest()
        {
            var result = Tools.GetResultPart1(@"Data\input.dat");
            Assert.AreEqual(2275, result);
        }

        [Test]
        public void SimpleTest()
        {
            var result = Tools.GetResultPart1(@"Data\simple.dat");
            Assert.AreEqual(37, result);
        }
    }
}