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
        }

        [Test]
        public void SimpleTest()
        {
            var result = Tools.GetResultPart1(@"Data\simple.dat");
            Assert.AreEqual(25, result);
        }
    }
}